using ECommerceAPI.DTOs;
using MediatR;

namespace ECommerceAPI.Commands
{
    public record UpdateOrderStatusCommand(Guid OrderId, DTOOrderUpdate orderupdate) : IRequest;
}
