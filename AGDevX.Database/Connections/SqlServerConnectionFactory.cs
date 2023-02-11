using System.Data;
using System.Data.SqlClient;

namespace AGDevX.Database.Connections
{
    public sealed class SqlServerConnectionFactory : IDbConnectionProvider
    {
        private readonly DatabaseConnection _databaseConnection;

        public SqlServerConnectionFactory(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_databaseConnection.ConnectionString);
        }

        public IDbConnection GetOpenConnection()
        {
            var conn = GetConnection();
            conn.Open();
            return conn;
        }
    }
}