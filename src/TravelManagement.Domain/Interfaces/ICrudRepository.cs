using TravelManagement.Domain.Common;

namespace TravelManagement.Infra.Data.Repositories;

public interface ICrudRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task InsertAsync(TEntity entity);

    Task InsertAsync(IEnumerable<TEntity> entities);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(string id);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}
