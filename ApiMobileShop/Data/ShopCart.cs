using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobileShop.Data
{
    [Table("ShopCart")]
    public class ShopCart
    {
        [Key]
        public int Id { get; set; }
        public int ShopCartID { get; set; }
        public int ShopProductID { get; set; }
        public virtual List<ShopProduct> Product { get; set; }
        public int Description { get; set; }
        public int Soluong { get; set; }
        public decimal Price { get; set; }
    }
}
