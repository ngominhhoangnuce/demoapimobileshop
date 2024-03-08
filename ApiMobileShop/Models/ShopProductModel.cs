using System.ComponentModel.DataAnnotations;

namespace ApiMobileShop.Models
{
    public class ShopProductModel
    {
        [Key]
        public int ShopProductID { get; set; }
        [Required]
        [Range(0, 10000000)]
        public decimal Price { get; set; }
        [Required]
        public string TenSp { get; set; }
        public string Description { get; set; }
        [Range(0, 5)]
        public int DanhGia { get; set; }
    }
}
