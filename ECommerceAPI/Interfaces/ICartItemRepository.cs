
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Interfaces
{
    public interface ICartItemRepository
    {
        public Task<IEnumerable<CartItem>> GetCartItems();
        public void Post(DTOAddCartItem cartItem);
    }
}
