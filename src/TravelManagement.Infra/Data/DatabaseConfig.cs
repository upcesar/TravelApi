namespace TravelManagement.Infra.Data;

public class DatabaseConfig
{
    public string ConnectionString { get; init; }

    public DatabaseConfig(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
