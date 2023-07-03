using ECommerceAPI.DTOs;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<Order> Checkout(DTOCheckOut checkout);
    }
}
