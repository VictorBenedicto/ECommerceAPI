using Dapper;
using ECommerceAPI.Contexts;
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;

namespace ECommerceAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcomDbContext _dbContext;
        private readonly DapperContext _dapperContext;

        public UserRepository(EcomDbContext dbContext, DapperContext dapperContext)
        {
            _dbContext = dbContext;
            _dapperContext = dapperContext;
        }

        public async Task<User> GetUser(Guid UserId)
        {
            var query = "SELECT * FROM Users WHERE UserId = @UserId";

            using (var connection = _dapperContext.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { UserId });

                return user;
            }
        }

        public void Post(DTOCreateUser user)
        {
            User nUser = new()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
            };
            _dbContext.Users.Add(nUser);
            _dbContext.SaveChanges();
        }
    }
}
