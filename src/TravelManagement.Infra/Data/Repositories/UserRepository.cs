using Dapper;
using TravelManagement.Domain.Entities;
using TravelManagement.Infra.Data.UoW;

namespace TravelManagement.Infra.Data.Repositories;

public class UserRepository : BaseRepository<Users>, IUserRepository
{
    public UserRepository(IUnitOfWork uow) : base(uow) { }

    public async Task<Users> GetByEmailAndPasswordAsync(string email, string password)
    {
        var sql = "SELECT * FROM [Users] (NOLOCK) WHERE [email] = @Email AND [password] = @Password";
        return await Connection.QuerySingleOrDefaultAsync<Users>(sql, new { email, password }, Transaction);
    }
}