using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Queries;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken) => await _orderRepository.GetOrders();
    }
}
