using System.Data;
using System.Data.SqlClient;

namespace TravelManagement.Infra.Data.Context;

public class DbContext : IDbContext
{
    private readonly DatabaseConfig _databaseConfig;

    public IDbConnection Connection { get; protected set; }

    public string ConnectionStringKey { get; protected set; }

    public DbContext(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public IDbContext SelectContext()
    {
        Connection ??= new SqlConnection(_databaseConfig.ConnectionString);

        if (Connection.State is not ConnectionState.Open)
        {
            Connection.Open();
        }

        return this;
    }


    public void Dispose()
    {
        if (Connection is not null && Connection.State is ConnectionState.Open)
        {
            Connection.Close();
        }

        Connection?.Dispose();
    }
}