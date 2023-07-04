using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Queries;
using MediatR;

namespace ECommerceAPI.Handlers
{
    public class GetUserByIdHandler : IRequestHandler <GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) => await _userRepository.GetUser(request.UserId);
    }
}
