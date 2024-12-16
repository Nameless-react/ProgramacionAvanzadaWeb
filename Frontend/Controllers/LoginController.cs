using Frontend.ApiModel;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Frontend.Models;
using Frontend.Helpers.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Frontend.Helpers.Implementations;


namespace Frontend.Controllers
{
    public class LoginController : Controller
    {
        ISecurityHelper securityHelper;
        public LoginController(ISecurityHelper securityHelper)
        {
            this.securityHelper = securityHelper;
        }


        
        public IActionResult Logout()
        {
            
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login(string ReturnedUrl = "/")
        {


            UserViewModel user = new UserViewModel();
            user.ReturnUrl = ReturnedUrl;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loging = securityHelper.Login(user);
                    TokenAPI tokenAPI = loging.Token;
                    var loginResult = securityHelper.Login(user);
                    var EsValido = false;

                    if (tokenAPI != null)
                    {
                        HttpContext.Session.SetString("token", tokenAPI.Token);
                        EsValido = true;
                    }

                    if (!EsValido)
                    {
                        ViewBag.Message = "Invalid Credencials";
                        return View(user);
                    }

                    HttpContext.Session.SetString("userLogged", loginResult.Username);

                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier, loging.Username as string),
                        new Claim(ClaimTypes.Name, loging.Username as string)
                    };

                    foreach (var item in loging.Roles)
                    {
                        claims.Add(
                        new Claim(ClaimTypes.Role, item as string)
                        );

                    }

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = user.RememberLogin
                    });
                    return LocalRedirect(user.ReturnUrl);
                }


                return View(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
