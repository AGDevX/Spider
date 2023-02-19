using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace AGDevX.Database.Dapper
{
    public static class DapperExtensions
    {
        public static async Task<IEnumerable<T>> ExecuteSproc<T>(this IDbConnection conn, string sprocName, object? paramObject = default)
        {
            return await conn.QueryAsync<T>(sprocName, paramObject, commandType: CommandType.StoredProcedure);
        }

        public static async Task<SqlMapper.GridReader> QueryMultiple(this IDbConnection conn, string sprocName, object? paramObject = default)
        {
            return await SqlMapper.QueryMultipleAsync(conn, sprocName, paramObject, commandType: CommandType.StoredProcedure);
        }
    }
}