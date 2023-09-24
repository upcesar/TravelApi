using Dapper.Contrib.Extensions;
using System.Data;
using TravelManagement.Domain.Common;
using TravelManagement.Infra.Data.UoW;

namespace TravelManagement.Infra.Data.Repositories;

public abstract class BaseRepository<TEntity> : ICrudRepository<TEntity> where TEntity : Entity
{
    protected IDbConnection Connection { get; init; }

    protected IDbTransaction Transaction { get; init; }

    public BaseRepository(IUnitOfWork uow)
    {
        var context = uow.Context.SelectContext();

        Transaction = uow.Transaction;
        Connection = context.Connection;
    }

    public async Task InsertAsync(TEntity entity)
    {
        await Connection.InsertAsync(entity);
    }

    public async Task InsertAsync(IEnumerable<TEntity> entities)
    {
        await Connection.InsertAsync(entities, Transaction);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Connection.GetAllAsync<TEntity>(Transaction);
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        return await Connection.GetAsync<TEntity>(id, Transaction);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await Connection.UpdateAsync(entity, Transaction);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await Connection.DeleteAsync(entity, Transaction);
    }

    public void Dispose()
    {
        if (Transaction != null)
        {
            Transaction.Rollback();
            Transaction.Dispose();
        }

        Connection?.Dispose();
    }
}
