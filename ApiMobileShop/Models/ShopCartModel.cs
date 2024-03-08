using System.ComponentModel.DataAnnotations;

namespace ApiMobileShop.Models
{
    public class ShopCartModel
    {
        [Key]
        public int ShopCartID { get; set; }
        public int ShopProductID { get; set; }
        public int Description { get; set; }
        public int Soluong { get; set; }
        public decimal Price { get; set; }
    }
}
