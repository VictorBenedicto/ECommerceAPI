
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Interfaces
{
    public interface ICartItemRepository
    {
        public Task<IEnumerable<CartItem>> GetCartItems();
        public Task<Guid> Post(DTOAddCartItem cartItem);
        public Task Put(Guid  CartItemId, DTOUpdateCartItem upcartitem);
        public Task Delete(Guid CartItemId);
    }
}
