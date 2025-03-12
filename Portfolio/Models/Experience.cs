using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string? Name { get; set; }

        [StringLength(100)]
        public string? Position { get; set; }

        public string? Description { get; set; }
        public string? Responsibilities { get; set; }
        public DateTime? FromDate { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
