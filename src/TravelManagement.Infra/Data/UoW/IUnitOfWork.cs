using System.Data;
using TravelManagement.Infra.Data.Context;

namespace TravelManagement.Infra.Data.UoW;

public interface IUnitOfWork : IDisposable
{
    IDbContext Context { get; }
    IDbTransaction Transaction { get; }
    IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);
    void Commit();
    void Rollback();
}
