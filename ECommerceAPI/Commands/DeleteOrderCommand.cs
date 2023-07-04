using MediatR;

namespace ECommerceAPI.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public DeleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
