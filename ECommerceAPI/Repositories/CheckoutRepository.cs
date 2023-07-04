using ECommerceAPI.Contexts;
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;

namespace ECommerceAPI.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly EcomDbContext _connection;

        public CheckoutRepository(EcomDbContext connection)
        {
            _connection = connection;
        }

        public async Task<Order> Checkout(DTOCheckOut checkout)
        {
            var cartitems = _connection.CartItems.FirstOrDefault(c => c.OrderId == checkout.OrderId);
            var UpOrder = _connection.Orders.FirstOrDefault(o => o.OrderId == checkout.OrderId);
            if (UpOrder == null || cartitems == null)
            {
                throw new Exception("Not Found");
            }
            else
            {
                UpOrder.OrderStatus = checkout.OrderStatus;
                _connection.Orders.Update(UpOrder);
                await _connection.SaveChangesAsync();
                return UpOrder;
            }
        }
    }
}
