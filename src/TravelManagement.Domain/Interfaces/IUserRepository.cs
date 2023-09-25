using TravelManagement.Domain.Entities;

namespace TravelManagement.Infra.Data.Repositories;

public interface IUserRepository : ICrudRepository<User>
{
    Task<User> GetByEmailAndPasswordAsync(string email, string password);
}
