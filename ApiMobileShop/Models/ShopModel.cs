using System.ComponentModel.DataAnnotations;

namespace ApiMobileShop.Models
{
    public class ShopModel
    {
        [Key]
        public int ShopID { get; set; }
        [Required]
        [Range(0, 10000000)]
        public decimal Price { get; set; }
        [Required]
        public string TenSp { get; set; }
        [Range(0, 5)]
        public int DanhGia { get; set; }
    }
}
