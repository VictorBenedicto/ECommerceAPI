using Dapper;
using ECommerceAPI.Contexts;
using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;

namespace ECommerceAPI.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly EcomDbContext _dbcontext;
        private readonly DapperContext _dapperContext;

        public CartItemRepository(EcomDbContext dbcontext, DapperContext dapperContext)
        {
            _dbcontext = dbcontext;
            _dapperContext = dapperContext;
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

        public void Post(DTOAddCartItem cartItem)
        {
            CartItem NCartItem = new()
            {
                CartItemName = cartItem.CartItemName,
            };
            _dbcontext.CartItems.Add(NCartItem);
            _dbcontext.SaveChanges();
        }
    }
}
