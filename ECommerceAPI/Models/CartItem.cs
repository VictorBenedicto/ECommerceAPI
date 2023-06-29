namespace ECommerceAPI.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public string? CartItemName { get; set; }
        public int Quantity { get; set; }
    }
}
