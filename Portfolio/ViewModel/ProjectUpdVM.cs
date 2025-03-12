using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
    public class ProjectUpdVM
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Title is required"), MaxLength(255)]
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
    }
}
