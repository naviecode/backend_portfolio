using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("Blogs")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required, MaxLength(255)]
        public string? Title { get; set; }

        public string? Content { get; set; }

        [MaxLength(255)]
        public string? Tags { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
