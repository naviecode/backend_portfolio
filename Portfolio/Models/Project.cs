using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required, MaxLength(255)]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [MaxLength(255)]
        public string? Technologies { get; set; }

        [MaxLength(255), DataType(DataType.Url)]
        public string? GitHubLink { get; set; }

        [MaxLength(255), DataType(DataType.Url)]
        public string? DemoLink { get; set; }

        [MaxLength(255)]
        public string? Image { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
