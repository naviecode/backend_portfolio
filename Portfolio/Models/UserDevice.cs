using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("user_devices")]
    public class UserDevice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required, MaxLength(255)]
        public string? DeviceId { get; set; }

        [MaxLength(255)]
        public string? DeviceName { get; set; }
    }
}
