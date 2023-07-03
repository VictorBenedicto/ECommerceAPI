using ECommerceAPI.Entities;

namespace ECommerceAPI.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrders();
        public Task<Order> GetOrder(Guid OrderId);
    }
}
