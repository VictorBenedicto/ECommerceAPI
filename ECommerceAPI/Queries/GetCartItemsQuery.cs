using ECommerceAPI.Entities;
using MediatR;

namespace ECommerceAPI.Queries
{
    public record GetCartItemsQuery() : IRequest<IEnumerable<CartItem>>;
    
}
