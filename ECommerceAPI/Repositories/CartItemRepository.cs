using Dapper;
using ECommerceAPI.Contexts;
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly EcomDbContext _connection;
        private readonly DapperContext _dapperContext;
        private readonly IHttpContextAccessor _contextAccesor;

        public CartItemRepository(EcomDbContext connection, DapperContext dapperContext, IHttpContextAccessor contextAccessor)
        {
            _connection = connection;
            _dapperContext = dapperContext;
            _contextAccesor = contextAccessor;
        }

        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            var query = "SELECT * FROM CartItems";

            using(var connection = _dapperContext.CreateConnection())
            {
                var cartitems = await connection.QueryAsync<CartItem>(query);
                return cartitems.ToList();
            }
        }

        public async Task<Guid> Post(DTOAddCartItem cartItem)
        {
            var userId = _contextAccesor.HttpContext!.Request.Headers["x-user-id"].FirstOrDefault();
            Guid guserId = Guid.Parse(userId!);
            var user = await _connection.Users.FirstOrDefaultAsync(user => user.UserId == guserId);
            var orderChecker = await _connection.Orders.FirstOrDefaultAsync(order => order.UserId == guserId && order.OrderStatus == 0);

            CartItem nCartItem = new()
            {
                CartItemName = cartItem.CartItemName,
                UserId = user!.UserId,
            };

            if(orderChecker != null && orderChecker.OrderStatus == 0) 
            {
                nCartItem.OrderId = orderChecker.OrderId;
                orderChecker.CartItems.Add(nCartItem);
                _connection.Orders.Update(orderChecker);
            }
            else
            {
                Order order = new()
                {
                    UserId = user!.UserId,
                    CartItems = new List<CartItem>()
                    {
                        nCartItem
                    }
                };
                _connection.Orders.Add(order);
            }
            await _connection.SaveChangesAsync();
            return nCartItem.CartItemId;
        }

        public bool Put(Guid CartItemId, DTOUpdateCartItem upcartitem)
        {
            var ChangeCartItem = _connection.CartItems.FirstOrDefault(c => c.CartItemId.Equals(CartItemId));
            if (ChangeCartItem != null)
            {
                ChangeCartItem.CartItemName = upcartitem.CartItemName;
                _connection.CartItems.Update(ChangeCartItem);
                _connection.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(Guid CartItemId)
        {
            var DeleteCartItem = _connection.CartItems.FirstOrDefault(c => c.CartItemId.Equals(CartItemId));
            if (DeleteCartItem != null)
            {
                _connection.CartItems.Remove(DeleteCartItem);
                _connection.SaveChanges();
            }
        }
    }
}
