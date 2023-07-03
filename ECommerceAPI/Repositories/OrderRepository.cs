using Dapper;
using ECommerceAPI.Contexts;
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
    }
}
