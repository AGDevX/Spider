using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AGDevX.IEnumerables
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            var isNullOrEmpty = enumerable == null;
            isNullOrEmpty = isNullOrEmpty || !enumerable!.Any();
            return isNullOrEmpty;
        }

        public static bool HasCommonStringElement(this IEnumerable<string> enumerable1, IEnumerable<string> enumerable2, StringComparer? stringComparer = default)
        {
            if (enumerable1 == null)
            {
                throw new ArgumentNullException($"The provided { nameof(enumerable1) } argument was null");
            }

            if (enumerable2 == null)
            {
                throw new ArgumentNullException($"The provided { nameof(enumerable2) } argument was null");
            }

            stringComparer ??= StringComparer.OrdinalIgnoreCase;

            return enumerable1.Intersect(enumerable2, stringComparer).Any();
        }

        public static DataTable ToIdDataTable<T>(this IEnumerable<T> ids, string idColumnName = "Id")
        {
            var dataTable = new DataTable("IdDataTable");
            dataTable.Columns.Add(idColumnName);

            if (ids.IsNullOrEmpty())
            {
                return dataTable;
            }

            Parallel.ForEach(ids, id =>
            {
                dataTable.Rows.Add(id);
            });

            return dataTable;
        }

        public static bool ContainsStringIgnoreCase(this IEnumerable<string> strings, string str, StringComparer? stringComparer = default)
        {
            if (strings.IsNullOrEmpty())
            {
                throw new ArgumentNullException($"The provided {nameof(strings)} argument was null");
            }

            stringComparer ??= StringComparer.OrdinalIgnoreCase;

            return strings.Contains(str, stringComparer);
        }
    }
}