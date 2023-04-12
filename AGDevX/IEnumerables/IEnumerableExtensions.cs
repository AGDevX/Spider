using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AGDevX.IEnumerables;

public static class IEnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable)
    {
        var isNullOrEmpty = enumerable == null;
        isNullOrEmpty = isNullOrEmpty || !enumerable!.Any();
        return isNullOrEmpty;
    }

    public static bool HasCommonStringElement(this IEnumerable<string>? enumerable1, IEnumerable<string>? enumerable2, StringComparer? stringComparer = default)
    {
        if (enumerable1 == null || enumerable2 == null)
        {
            return false;
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

        foreach(var id in ids)
        {
            dataTable.Rows.Add(id);
        }

        return dataTable;
    }

    public static bool ContainsIgnoreCase(this IEnumerable<string?>? strings, string? str, StringComparer? stringComparer = default)
    {
        if (strings.IsNullOrEmpty())
        {
            return false;
        }

        stringComparer ??= StringComparer.OrdinalIgnoreCase;

        return strings!.Contains(str, stringComparer);
    }

    public static bool AnySafe<T>(this IEnumerable<T>? enumerable)
    {
        return enumerable != null && enumerable.Any();
    }
}