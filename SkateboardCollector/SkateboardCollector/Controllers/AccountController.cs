using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkateboardCollector.Domain;
using SkateboardCollector.Services;

namespace SkateboardCollector.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IDataBaseService _dbService;
        public AccountController(ILogger<AccountController> logger,IDataBaseService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(string nickname,string email,string password)
        {
            if(nickname == null || email == null || password == null)
            {
                return RedirectToAction("Register");
            }
            else
            {
                _dbService.RegisterUser(nickname, email, password);
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        /*public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            if ("test@test.com" == email && "123" == password)
            {
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }*/
        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromForm] string email, [FromForm] string password)
        {
            User user = _dbService.Login(email, password);
            if(user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.UserEmail),
                    
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return RedirectToAction("Index", "Profile");
            
        }
    }
}
