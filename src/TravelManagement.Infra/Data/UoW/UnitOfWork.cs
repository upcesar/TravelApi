using System.Data;
using TravelManagement.Infra.Data.Context;

namespace TravelManagement.Infra.Data.UoW;

public sealed class UnitOfWork : IUnitOfWork
{
    #region Atributes

    public IDbContext Context { get; private set; }

    public IDbTransaction Transaction { get; private set; }

    #endregion

    #region Constructors
    public UnitOfWork(IDbContext context)
    {
        Context = context;
    }

    #endregion

    #region Public Methods
    public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
    {
        if (Transaction is null)
        {
            Transaction = Context.Connection.BeginTransaction(isolationLevel);
        }

        return Transaction;
    }

    public void Commit()
    {
        if (Transaction is not null)
        {
            Transaction.Commit();
            DisposeTransaction();
        }

    }

    public void Rollback()
    {
        if (Transaction is not null)
        {
            Transaction.Rollback();
            DisposeTransaction();
        }
    }

    public void Dispose()
    {
        Rollback();

        DisposeContext();
    }

    #endregion

    #region Private Methods

    private void DisposeContext()
    {
        if (Context is not null)
        {
            Context.Dispose();
            Context = null;
        }
    }

    private void DisposeTransaction()
    {
        Transaction.Dispose();
        Transaction = null;
    }

    #endregion
}
