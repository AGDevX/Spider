using System.Data;

namespace AGDevX.Database.Connections
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetOpenConnection();
    }
}