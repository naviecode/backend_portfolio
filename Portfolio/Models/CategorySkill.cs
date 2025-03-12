using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("CategorySkill")]   
    public class CategorySkill
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string? Title { get; set; }
        public ICollection<Skill>? Skills { get; set; }
    }
}
