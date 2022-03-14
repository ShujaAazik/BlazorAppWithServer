using System.ComponentModel.DataAnnotations;

namespace UserManagement___FrontEnd
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(25,ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Name is too long.")]
        public string Address { get; set; }
    }
}
