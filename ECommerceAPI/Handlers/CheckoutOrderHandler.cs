using ECommerceAPI.Commands;
using ECommerceAPI.Interfaces;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand>
    {
        private readonly ICheckoutRepository _checkoutRepository;
        public CheckoutOrderHandler(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }

        public async Task Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            await _checkoutRepository.Checkout(request._checkout);
            return;
        }
    }
}
