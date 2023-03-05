using AGDevX.Database.Connections;
using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Connections
{
    public sealed class DbConnectionFactoryTests
    {
        [Fact]
        public async void CreateAndOpenConnection_SqlServer_ReturnsOpenSqlServerConnection()
        {
            //-- Arrange
            var databaseConnection = new DatabaseConnection { SqlServerConnectionString = "Data Source=(local);Initial Catalog=Amara_Local;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=60" };
            var sqlServerConnectionFactory = new DbConnectionFactory(databaseConnection);

            //-- Act
            var conn = await sqlServerConnectionFactory.CreateAndOpenConnection(DatabaseProviderType.SqlServer);

            //-- Assert
            Assert.True(conn.State == System.Data.ConnectionState.Open);
        }

        [Fact]
        public void CreateAndOpenConnection_SqlServer_NoConnectionString_ThrowsMissingDbConnectionStringException()
        {
            //-- Arrange
            var databaseConnection = new DatabaseConnection { SqlServerConnectionString = string.Empty };
            var sqlServerConnectionFactory = new DbConnectionFactory(databaseConnection);

            //-- Act && Assert
            Assert.ThrowsAsync<MissingDbConnectionStringException>(async () => await sqlServerConnectionFactory.CreateAndOpenConnection(DatabaseProviderType.SqlServer));

        }

        [Fact]
        public void CreateAndOpenConnection_NoType_ThrowsDatabaseProviderNotSupportedException()
        {
            //-- Arrange
            var databaseConnection = new DatabaseConnection { SqlServerConnectionString = "Data Source=(local);Initial Catalog=Amara_Local;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=60" };
            var sqlServerConnectionFactory = new DbConnectionFactory(databaseConnection);

            //-- Act && Assert
            Assert.ThrowsAsync<DatabaseProviderNotSupportedException>(async () => await sqlServerConnectionFactory.CreateAndOpenConnection(0));
        }
    }
}