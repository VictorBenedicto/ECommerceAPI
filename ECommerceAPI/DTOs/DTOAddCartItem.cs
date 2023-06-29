using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs
{
    public class DTOAddCartItem
    {
        [Required]
        public string? CartItemName { get; set; }
    }
}
