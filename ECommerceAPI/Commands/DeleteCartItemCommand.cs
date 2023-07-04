using MediatR;

namespace ECommerceAPI.Commands
{
    public class DeleteCartItemCommand : IRequest
    {
        public Guid CartItemId { get; set; }

        public DeleteCartItemCommand(Guid cartItemId)
        {
            CartItemId = cartItemId;
        }
    }
}
