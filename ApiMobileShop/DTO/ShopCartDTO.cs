namespace ApiMobileShop.DTO
{
    public class ShopCartDTO
    {
        public int ShopCartID { get; set; }
        public int ShopProductID { get; set; }
        public int Description { get; set; }
        public int Soluong { get; set; }
        public decimal Price { get; set; }
    }
    public class ShopCartResponseDTO
    {
        public int Id { get; set; }
        public int ShopCartID { get; set; }
        public int ShopProductID { get; set; }
        public int Description { get; set; }
        public int Soluong { get; set; }
        public decimal Price { get; set; }
    }
}
