using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using CleanSync.Components;
using CleanSync.Infrastructure.Data;
using CleanSync.Infrastructure.Services;
using CleanSync.Services;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CleanSync
{
    public partial class MainWindow : Window
    {

        private SqlConnection _connection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += ShortcutKeyToReset;
        }

        private void ShortcutKeyToReset(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2) ClearDatabase();
        }


        private void RunCleanDB(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                @"ATENÇÃO!

Essa operação é irreversível.
Você está prestes a executar um processo crítico de limpeza de dados no banco de dados atualmente conectado.
Certifique-se de que este banco é o que será utilizado pelo Bridge, pois todas alterações realizadas não poderão ser desfeitas.

Deseja realmente continuar?

Confirmação de Operação Crítica
                ",

                "Leia com atenção",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result != MessageBoxResult.Yes)
            {
                MessageBox.Show("Operacao cancelada");
                return;
            }

            ClearDatabase();
        }

        private async Task ClearDatabase()
        {
            try
            {
                TerminalLogger.WriteToTerminal(TerminalOutput, "Iniciando conexão com o banco de dados...");

                var databaseConfig = FileReader.ReadConfig();
                var databaseConnection = new DatabaseConnection();

                using (var connection = databaseConnection.ConnectDatabse(databaseConfig))
                {
                    UpdateConnectionStatus(connection);

                    long tamanhoAntes = await GetDatabaseSize(connection);

                    Cleaner cleaner = new Cleaner(TerminalOutput);
                    await cleaner.CleanerDB(connection);

                    long tamanhoDepois = await GetDatabaseSize(connection);

                    long espacoLiberado = tamanhoAntes - tamanhoDepois;

                    TerminalLogger.WriteToTerminal(TerminalOutput, $"Espaço liberado no banco: {espacoLiberado} KB");
                }

                UpdateDisconnectedStatus();
            }
            catch (Exception error)
            {
                TerminalLogger.WriteToTerminal(TerminalOutput, $"Erro: {error.Message}");
            }
        }

        private void HelpMe(object sender, MouseButtonEventArgs e)
        {
            Help helpCleanSync = new Help();
            helpCleanSync.ShowDialog();
        }

        private async Task<long> GetDatabaseSize(SqlConnection connection)
        {
            string query = @"
                SELECT SUM(reserved_page_count) * 8 AS SizeKB
                FROM sys.dm_db_partition_stats";

            return await connection.ExecuteScalarAsync<long>(query);
        }

        private void UpdateDisconnectedStatus()
        {
            ConnectionStatus.Dispatcher.Invoke(() =>
            {
                ConnectionStatus.Text = "🔴 Banco: desconectado!";
                ConnectionStatus.Foreground = Brushes.Red;
            });
        }

        private void UpdateConnectionStatus(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                ConnectionStatus.Dispatcher.Invoke(() =>
                {
                    ConnectionStatus.Text = "🟢 Banco: conectado!";
                    ConnectionStatus.Foreground = Brushes.Green;
                });
            }
            else
            {
                ConnectionStatus.Dispatcher.Invoke(() =>
                {
                    ConnectionStatus.Text = "⚪ Status desconhecido";
                    ConnectionStatus.Foreground = Brushes.Gray;
                });
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o link: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}