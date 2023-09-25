using Dapper;
using TravelManagement.Domain.Entities;
using TravelManagement.Infra.Data.UoW;

namespace TravelManagement.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IUnitOfWork uow) : base(uow) { }

    public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
    {
        var sql = "SELECT * FROM [Users] (NOLOCK) WHERE [email] = @Email AND [password] = @Password";
        return await Connection.QuerySingleOrDefaultAsync<User>(sql, new { email, password }, Transaction);
    }
}