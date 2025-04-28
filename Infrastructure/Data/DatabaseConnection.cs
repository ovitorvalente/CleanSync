using CleanSync.Domain.Entities;
using CleanSync.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace CleanSync.Infrastructure.Data
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public SqlConnection ConnectDatabse(DatabaseConfig config)
        {
            var connectionString = $"Server={config.DataSource}; Database=ETrade; User Id={config.User}; Password={config.Password}; TrustServerCertificate=True; Connection Timeout={config.Timeout}";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
