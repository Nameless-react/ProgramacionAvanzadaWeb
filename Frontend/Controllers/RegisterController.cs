using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Frontend.Controllers
{
    public class RegisterController : Controller
    {

        IRegisterHelper _registerHelper;
        public RegisterController(IRegisterHelper registerHelper)
        {

            this._registerHelper = registerHelper;
        }

        public IActionResult Register()
        {
            RegisterViewModel user = new RegisterViewModel();
    
            return View(user);
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var loging = _registerHelper.RegisterUser(user);
                    
                    return RedirectToAction("Index", "Home");
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
