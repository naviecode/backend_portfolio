using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("Profile")]
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Fullname is required")]
        public string? FullName { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }
        public string? Bio { get; set; }

        [MaxLength(100), DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }

        [MaxLength(255)]
        public string? LinkedIn { get; set; }

        [MaxLength(255)]
        public string? GitHub { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
