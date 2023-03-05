using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AGDevX.Database.Exceptions;
using AGDevX.Strings;

namespace AGDevX.Database.Connections
{
    public sealed class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly DatabaseConnection _databaseConnection;

        public DbConnectionFactory(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<IDbConnection> CreateAndOpenConnection(DatabaseProviderType databaseProviderType)
        {
            return databaseProviderType switch
            {
                DatabaseProviderType.SqlServer => await CreateAndOpenSqlServerConnection(),
                _ => throw new DatabaseProviderNotSupportedException()
            };
        }

        private async Task<IDbConnection> CreateAndOpenSqlServerConnection()
        {
            if (_databaseConnection.SqlServerConnectionString.IsNullOrWhiteSpace())
            {
                throw new MissingDbConnectionStringException("Missing Sql Server connection string");
            }

            var conn = new SqlConnection(_databaseConnection.SqlServerConnectionString);
            await conn.OpenAsync();
            return conn;
        }
    }
}