using System.Data;
using System.Threading.Tasks;

namespace AGDevX.Database.Connections;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateAndOpenConnection(DatabaseProviderType databaseProviderType);
}