using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [Column("UserName")]
        [MaxLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [Column("Email")]
        [MaxLength(100, ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Column("PasswordHash")]
        [MaxLength(200, ErrorMessage = "Password cannot be longer than 200 characters")]
        public string? Password { get; set; }
        [Column("Role")]
        [MaxLength(20, ErrorMessage = "Role cannot be longer than 20 characters")]
        public string? Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
