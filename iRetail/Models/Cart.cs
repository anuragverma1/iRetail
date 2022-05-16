namespace iRetail.Models
{
    public class Cart
    {
        public string Username { get; set; } = string.Empty;
        public Guid Productid { get; set; } = Guid.Empty;
        public int Quantity { get; set; }
    }
}
