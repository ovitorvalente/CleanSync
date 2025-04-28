using CleanSync.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace CleanSync.Domain.Interfaces
{
    public interface IDatabaseConnection
    {
        SqlConnection ConnectDatabse(DatabaseConfig config);
    }
}
