using Frontend.ApiModel;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        public List<string>? Roles { get; set; }
    }
}
