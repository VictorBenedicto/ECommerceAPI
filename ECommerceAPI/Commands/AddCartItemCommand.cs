using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;
using MediatR;

namespace ECommerceAPI.Commands
{
    public record AddCartItemCommand (DTOAddCartItem cartItem) : IRequest;
}
