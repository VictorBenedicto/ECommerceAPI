using ECommerceAPI.DTOs;
using MediatR;

namespace ECommerceAPI.Commands
{
    public record ChangeCartItemCommand(Guid CartItemId, DTOUpdateCartItem CartItem) : IRequest;
}
