using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobileShop.Data
{
    [Table("ShopProduct")]
    public class ShopProduct
    {
        [Key]
        public int ShopProductID { get; set; }
        [Required]
        [Range(0, 10000000)]
        public decimal Price { get; set; }
        [Required]
        public string TenSp { get; set; }
        public string Description { get; set; }
        public ShopCart ShopCart { get; set; }
        [Range(0, 5)]
        public int DanhGia { get; set; }
    }
}
