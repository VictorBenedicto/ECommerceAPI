using Dapper;
using ECommerceAPI.Contexts;
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;

namespace ECommerceAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcomDbContext _connection;
        private readonly DapperContext _dapperContext;

        public OrderRepository(EcomDbContext connection, DapperContext dapperContext)
        {
            _connection = connection;
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var query = "SELECT * FROM Orders";

            using (var connection = _dapperContext.CreateConnection())
            {
                var orders = await connection.QueryAsync<Order>(query);
                return orders.ToList();
            }
        }

        public async Task<Order> GetOrder(Guid OrderId)
        {
            var query = "SELECT * FROM Orders WHERE OrderId = @OrderId";

            using (var connection = _dapperContext.CreateConnection())
            {
                var order = await connection.QuerySingleOrDefaultAsync<Order>(query, new { OrderId });
                return order;
            }
        }

       public async Task Put(Guid OrderId, DTOOrderUpdate uporder)
        {
            var ChangeOrder = _connection.Orders.FirstOrDefault(o => o.OrderId.Equals(OrderId)) ?? throw new Exception("Not Found");
            ChangeOrder.OrderStatus = uporder.OrderStatus;
            _connection.Orders.Update(ChangeOrder);
            await _connection.SaveChangesAsync();
        }

        public async Task Delete(Guid OrderId)
        {
            var order = _connection.Orders.FirstOrDefault(o => o.OrderId == OrderId) ?? throw new Exception("Not Found");
            if (order != null)
            {
                _connection.Orders.Remove(order);
                await _connection.SaveChangesAsync();
            }
        }
    }
}
