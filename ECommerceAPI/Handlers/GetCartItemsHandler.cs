using ECommerceAPI.Contexts;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Queries;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<CartItem>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetCartItemsHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken) => await _cartItemRepository.GetCartItems();
    }
}
