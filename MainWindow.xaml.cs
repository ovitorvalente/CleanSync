using System.Windows;
using System.Windows.Input;

namespace CleanSync
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

            MessageBox.Show("Iniciando Operacao");
            ClearDatabase();
        }

        private void ClearDatabase()
        {

        }
    }
}