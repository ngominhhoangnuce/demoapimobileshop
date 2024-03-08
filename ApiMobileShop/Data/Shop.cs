using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobileShop.Data
{
    [Table("Shop")] 
    public class Shop
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
