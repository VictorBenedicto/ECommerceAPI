using ECommerceAPI.DTOs;
using MediatR;

namespace ECommerceAPI.Commands
{
    public class CheckoutOrderCommand : IRequest
    {
        public DTOCheckOut _checkout { get; set; }
        public CheckoutOrderCommand(DTOCheckOut checkout)
        {
            _checkout = checkout;
        }
    }
}
