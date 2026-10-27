using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using solfagito_learn.Models;
using solfagito_learn.Models.Users;
using solfagito_learn.Services.Interface;
using System.Security.Claims;

namespace solfagito_learn.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AuthController : Controller
    {
        private readonly ILoginServices _loginServices;
        public AuthController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var users = await _loginServices.LoginAsync(model.Email, model.Password);
                if (users.sucess = false)
                {
                    ViewBag.ErrorMessage = users.message;
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , users.user!.Name),
                    new Claim(ClaimTypes.NameIdentifier , users.user.Id.ToString()),
                    new Claim(ClaimTypes.Role , users.user.Role.Role_name)
                };
                var Identity = new ClaimsIdentity(claims ,CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(Identity);

                var authproperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = model.RememberMe? DateTimeOffset.UtcNow.AddDays(5) : null 
                };

                await HttpContext.SignInAsync("CookieAuth",principle , authproperties);

                return RedirectToAction("Dashboard", "Admin");
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<IActionResult> Logout(LoginModel model)
        {
            await HttpContext.SignOutAsync("CookieAuth");

            return RedirectToAction("Login", "Auth");
        }

    }
}
