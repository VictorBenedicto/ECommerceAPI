using ECommerceAPI.Commands;
using ECommerceAPI.Interfaces;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class AddCartItemHandler : IRequestHandler<AddCartItemCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public AddCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task Handle(AddCartItemCommand request,  CancellationToken cancellationToken)
        {
            await _cartItemRepository.Post(request.cartItem);
            return;
        }
    }
}
