namespace ApiMobileShop.Data
{
    public class OrderDetail
    {
        public string Id { get; set; } = string.Empty;
        public string ShopProductID { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual ShopProduct Product { get; set; }
        public OrderDetail()
        {
        }
    }
}
