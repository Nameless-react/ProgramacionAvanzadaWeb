using System.ComponentModel.DataAnnotations;

namespace Backend.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public TokenDTO? Token { get; set; }

        public List<string>? Roles { get; set; }
    }
}
