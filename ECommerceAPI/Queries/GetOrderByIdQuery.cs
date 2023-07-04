using ECommerceAPI.Entities;
using MediatR;

namespace ECommerceAPI.Queries
{
    public record GetOrderByIdQuery(Guid OrderId): IRequest<Order>;
}
