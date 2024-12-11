using System.ComponentModel.DataAnnotations;

namespace Frontend.ApiModel
{
    public class RegisterAPI
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public TokenAPI? Token { get; set; }

        public List<string>? Roles { get; set; }
    }
}
