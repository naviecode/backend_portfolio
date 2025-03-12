using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string? Name { get; set; }

        public int? CategorySkillId { get; set; }
        [ForeignKey("CategorySkillId")]
        public CategorySkill? CategorySkill { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
