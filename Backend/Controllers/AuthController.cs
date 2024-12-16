using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private IAccessReportService _accessReportService { get; set; }
        private ITokenService TokenService;



        public AuthController(UserManager<IdentityUser> userManager, ITokenService tokenService, RoleManager<IdentityRole> roleManager, IAccessReportService accessReportService)
        {
            this.userManager = userManager;
            this.TokenService = tokenService;
            this.roleManager = roleManager;
            this._accessReportService = accessReportService;
        }

       


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            IdentityUser user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber
            };



            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var roleExist = await roleManager.RoleExistsAsync("Consulta");
            if (!roleExist)
            {
                // Si el rol no existe, lo creamos
                var roleResult = await roleManager.CreateAsync(new IdentityRole("Consulta"));
                if (!roleResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            var addRoleResult = await userManager.AddToRoleAsync(user, "Consulta");
            if (!addRoleResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            IdentityUser user = await userManager.FindByNameAsync(model.Username);
            LoginDTO Usuario = new LoginDTO();
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var jwtToken = TokenService.CreateToken(user, userRoles.ToList());

                Usuario.Token = jwtToken;
                Usuario.Roles = userRoles.ToList();
                Usuario.Username = user.UserName;



                _accessReportService.Add(new AccessReportDTO()
                {
                    //ClientId = 
                    IpAddress  = "127.0.0.1",
                    Success  = true,
                    AccessDescription = "Login"
                });

                return Ok(Usuario);
            }


            return Unauthorized();
        }
    }
}