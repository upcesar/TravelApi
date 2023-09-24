using System.Data;

namespace TravelManagement.Infra.Data.Context;

public interface IDbContext : IDisposable
{
    IDbConnection Connection { get; }

    string ConnectionStringKey { get; }

    IDbContext SelectContext();
}
