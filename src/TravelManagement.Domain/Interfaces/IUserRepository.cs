using TravelManagement.Domain.Entities;

namespace TravelManagement.Infra.Data.Repositories;

public interface IUserRepository : ICrudRepository<Users>
{
    Task<Users> GetByEmailAndPasswordAsync(string email, string password);
}
