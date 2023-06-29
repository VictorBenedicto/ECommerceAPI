using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs
{
    public class DTOCreateUser
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
    }
}
