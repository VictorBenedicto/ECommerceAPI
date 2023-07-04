using ECommerceAPI.Commands;
using ECommerceAPI.Interfaces;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class ChangeCartItemHandler : IRequestHandler<ChangeCartItemCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;
        public ChangeCartItemHandler (ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task Handle(ChangeCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartItemRepository.Put(request.CartItemId, request.CartItem);
            return;
        }
    }
}
