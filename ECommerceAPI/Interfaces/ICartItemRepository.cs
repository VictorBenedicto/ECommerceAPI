
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Interfaces
{
    public interface ICartItemRepository
    {
        public Task<IEnumerable<CartItem>> GetCartItems();
        public Task<Guid> Post(DTOAddCartItem cartItem);
        public bool Put(Guid  CartItemId, DTOUpdateCartItem upcartitem);
        public void Delete(Guid CartItemId);
    }
}
