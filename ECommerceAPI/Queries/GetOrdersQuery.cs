using ECommerceAPI.Entities;
using MediatR;

namespace ECommerceAPI.Queries
{
    public record GetOrdersQuery() : IRequest<IEnumerable<Order>>;

}
