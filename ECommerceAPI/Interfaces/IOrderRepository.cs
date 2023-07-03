using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrders();
        public Task<Order> GetOrder(Guid OrderId);
        public Task Put(Guid OrderId, DTOOrderUpdate uporder);
        public Task Delete(Guid OrderId);
    }
}
