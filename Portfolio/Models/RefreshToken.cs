using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("RefreshTokens")]
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        [Required, MaxLength(255)]
        public string? Token { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool? IsRevoked { get; set; }
        [Required]
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public UserDevice? UserDevice { get; set; }
    }
}
