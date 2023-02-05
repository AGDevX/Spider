using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace AGDevX.Database.Dapper
{
    public static class DapperExtensions
    {
        public static async Task<IEnumerable<T>> ExecuteSproc<T>(this IDbConnection conn, string name, object paramObject)
        {
            var data = await conn.QueryAsync<T>(name, paramObject, commandType: CommandType.StoredProcedure);
            return data;
        }
    }
}