using System.ComponentModel;
using AGDevX.Enums;

namespace AGDevX.Database.Connections;

public enum DatabaseProviderType
{
    [Description("Sql Server")]
    [EnumStringValue("Sql Server")]
    SqlServer = 1
}