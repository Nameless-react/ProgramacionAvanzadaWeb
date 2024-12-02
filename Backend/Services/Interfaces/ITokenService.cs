using Backend.DTO;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.Interfaces
{
    public interface ITokenService
    {
        TokenDTO CreateToken(IdentityUser user, List<string> roles);
    }
}
