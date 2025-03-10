using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModel
{
    public class LoginVM
    {
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = "";
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = "";
    }
}
