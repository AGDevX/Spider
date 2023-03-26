namespace AGDevX.Database.Config;

public sealed class DatabaseConfig
{
    public bool UseDatabase { get; set; } = true;
    public required string ConnectionString { get; set; }
}