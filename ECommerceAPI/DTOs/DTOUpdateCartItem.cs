using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs
{
    public class DTOUpdateCartItem
    {
        [Required]
        public string? CartItemName { get; set; }
    }
}
