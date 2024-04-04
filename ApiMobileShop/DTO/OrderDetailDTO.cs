using ApiMobileShop.Data;

namespace ApiMobileShop.DTO
{
    public class OrderDetailDTO
    {
        public string OrderDetailId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ShopProduct Product { get; set; }
        public OrderDetailDTO()
        {
            Product = new ShopProduct();
        }
    }
}
