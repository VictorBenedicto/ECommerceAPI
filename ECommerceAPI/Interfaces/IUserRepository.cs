using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUser(Guid UserId);
        public void Post(DTOCreateUser user);
    }
}
