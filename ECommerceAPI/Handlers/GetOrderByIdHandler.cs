using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Queries;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) => await _orderRepository.GetOrder(request.OrderId);
    }
}
