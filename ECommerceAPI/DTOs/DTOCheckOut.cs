using ECommerceAPI.Enums;

namespace ECommerceAPI.DTOs
{
    public class DTOCheckOut
    {
        public Guid OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
