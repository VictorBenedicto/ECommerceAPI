using ECommerceAPI.Commands;
using ECommerceAPI.Interfaces;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.Delete(request.OrderId);
            return;
        }
    }
}
