namespace RetailInventory.Models
{
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }

        public string WarrantyInfo { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}