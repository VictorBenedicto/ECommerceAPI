using ECommerceAPI.Entities;
using MediatR;

namespace ECommerceAPI.Queries
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<User>;
}
