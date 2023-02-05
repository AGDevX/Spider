using System.Data;
using System.Data.SqlClient;

namespace AGDevX.Database.Connections
{
    public class SqlServerConnectionProvider : IDbConnectionProvider
    {
        private readonly string _connectionString;

        private SqlConnection? _connection;
        public SqlConnection Connection => _connection ??= new SqlConnection(_connectionString);

        public SqlServerConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            Connection.Open();
            return Connection;
        }
    }
}