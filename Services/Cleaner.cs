using System.Data;
using System.Windows.Controls;
using System.Windows.Documents;
using CleanSync.Components;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CleanSync.Services
{
    public class Cleaner
    {
        private TextBox _terminalOutput;

        public Cleaner(TextBox terminalOutput)
        {
            _terminalOutput = terminalOutput;
        }
        public async Task CleanerDB(SqlConnection connection)
        {
            try
            {
                await Task.Run(async () =>
                {
                    _terminalOutput.Dispatcher.Invoke(() 
                        => TerminalLogger.WriteToTerminal(_terminalOutput, "Conexão estabelecida com sucesso!"));
                    await Task.Delay(1000);

                    _terminalOutput.Dispatcher.Invoke(() 
                        => TerminalLogger.WriteToTerminal(_terminalOutput, $"Iniciando processo de limpeza...\n"));

                    await DeleteTables(connection);

                    _terminalOutput.Dispatcher.Invoke(() 
                        => TerminalLogger.WriteToTerminal(_terminalOutput, "Limpeza concluída com sucesso!"));
                });
            }
            catch (SqlException ex)
            {
                throw new Exception($"Erro ao limpar o banco de dados: {ex.Message}");
            }
        }


        private async Task DeleteTables(IDbConnection connection)
        {
            int count = 0;

            string[] tables =
            {
                "MovimentoProdutoEncomenda",
                "ICMS_UFs",
                "Canal_Abastecimento_Bico",
                "Analytics",
                "MovimentoProdutoKds",
                "CampanhaPromocional",
                "Certificado",
                "BandeiraCartao",
                "ContaBancariaCarteira",
                "GarcomNotificacao",
                "Post",
                "Fuel_Status",
                "Delivery",
                "ManifestoDestinatario",
                "AdministradoraCartaoParcela",
                "ManifestoDestinatarioEvento",
                "MovimentoMDFe",
                "Filial_Foto",
                "ProdutoUltimaCompra",
                "Email_Log",
                "Financeiro_Caixa_Link",
                "HorarioFuncionamento",
                "Funcionario_Filial",
                "MovimentoProdutoEntrega",
                "FuncionariosPermissoes",
                "Funcionario_Operacao",
                "MovimentoConferenciaPedido",
                "Fuel_Abastecimento_Online",
                "Log",
                "PDV",
                "Movimento_Financeiro",
                "MedicaoItem",
                "Movimento_Produto",
                "AreaEntrega",
                "FinanceiroContaContrato",
                "MovimentoNFeCartaCorrecao",
                "Transferencia",
                "Expedicao",
                "Fuel_Abastecimento",
                "ExpedicaoProduto",
                "Usuarios_Ativos_Log",
                "Movimento_NFe_Evento",
                "Classe_Foto",
                "Machine",
                "Subclasse_Foto",
                "Permissao_Grupo_Filial",
                "Grupo_Foto",
                "Permissao",
                "Familia_Foto",
                "Transferencia_Produto",
                "Movimento_TEF",
                "Financeiro_Caixa_Mov",
                "Servidor_Email",
                "ProdutoImendes",
                "Produto_RemarcaPreco",
                "MovimentoNuvemShopStatus",
                "ClubCotacao",
                "Usuarios_Ativos",
                "Movimento_NFe",
                "Movimento",
                "Financeiro_Conta",
                "Permissao_Grupo_Operacao",
                "Cli_For_Contato",
                "MovimentoDocumentoReferenciado",
                "MesaReserva",
                "LayoutImpressaoField",
                "CliForTabelaPrecoPadrao",
                "Cst",
                "Etiqueta",
                "Favorito_Produto",
                "ContaBancariaMov",
                "Movimento_Mesa",
                "MoedaCotacao",
                "Movimento_OS",
                "MovimentoDeliveryIfoodConhecimento",
                "Movimento_Delivery_Status",
                "Cli_For_Grupo_Mala_Direta",
                "Jazigo",
                "Canal_Abastecimento"
            };

            foreach (string table in tables)
            {
                try
                {
                    await connection.ExecuteAsync($"DELETE FROM {table}");

                    _terminalOutput.Dispatcher.Invoke(() =>
                        TerminalLogger.WriteToTerminal(_terminalOutput, $"Tabela {table} limpa!"));

                    count++;
                }
                catch (SqlException ex)
                {
                    _terminalOutput.Dispatcher.Invoke(() =>
                        TerminalLogger.WriteToTerminal(_terminalOutput, $"Erro ao limpar tabela {table}, operação revertida: {ex.Message}"));
                }
            }

            _terminalOutput.Dispatcher.Invoke(() 
                => TerminalLogger.WriteToTerminal(_terminalOutput, $"Total de tabelas limpas: {count}\n"));
        }
    }

}
