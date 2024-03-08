using System.ComponentModel.DataAnnotations;

namespace ApiMobileShop.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [MaxLength(250)]
        public string CompanyAddress { get; set; }
        [MaxLength(250)]
        public string HomeAddress { get; set; }
    }
}
