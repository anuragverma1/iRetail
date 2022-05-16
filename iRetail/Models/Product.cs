namespace iRetail.Model
{
    public class Product
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDesc { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public string ProductImageUrl { get; set; } = string.Empty;

    }
}
