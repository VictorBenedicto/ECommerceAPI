using ECommerceAPI.Commands;
using ECommerceAPI.Interfaces;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderStatusHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.Put(request.OrderId, request.orderupdate);
            return;
        }
    }
}
