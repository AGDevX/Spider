using System.ComponentModel;
using AGDevX.Enums;

namespace AGDevX.Spider.WebApi.Environment;

//-- E.g. Local, Dev, QA, Prod

public enum EnvironmentType
{
    [Description("Local")]
    [EnumStringValue("Local")]
    Local = 1,

    [Description("Dev (equivalent to Development)")]
    [EnumStringValue("Dev")]
    Dev = 2,

    [Description("Development")]
    [EnumStringValue("Development")]
    Development = 3,

    [Description("QA")]
    [EnumStringValue("QA")]
    QA = 4,

    [Description("Prod (equivalent to Production)")]
    [EnumStringValue("Prod")]
    Prod = 5,

    [Description("Production")]
    [EnumStringValue("Production")]
    Production = 6,

    //-- Typically the host isn't considered an environment, but it's being treated like a production environment to reduce API complexity for the educational aspect of this API
    [Description("Azure")]
    [EnumStringValue("Azure")]
    Azure = 7
}