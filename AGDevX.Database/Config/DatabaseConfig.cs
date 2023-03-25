namespace AGDevX.Database.Config;

public sealed class DatabaseConfig
{
    public bool UseDatabase { get; set; } = true;
    public string? SqlServerConnectionString { get; set; }
}