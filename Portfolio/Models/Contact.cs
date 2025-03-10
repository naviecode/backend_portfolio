using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required, MaxLength(100), DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
