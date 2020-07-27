using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkateboardCollector.Domain;
using SkateboardCollector.Services;

namespace SkateboardCollector.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IDataBaseService _dbService;
        private static string email;
        public ProfileController(IDataBaseService dbService)
        {
            _dbService = dbService;

        }
        

        public IActionResult Index()
        {
            email= HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var user = _dbService.GetOneUser(email);
            var tupleModel = new Tuple<User, List<Skateboard>>(new User(user.UserId, user.UserEmail, user.UserNickname, user.UserPw), _dbService.GetUserSkateboards(GetCurrentUser().UserId));
            return View(tupleModel);
            
        }

        public IActionResult AddSkateboardSlot()
        {
            var user = _dbService.GetOneUser(email);
            _dbService.AddSkateboardSlot(user.UserId);
            return RedirectToAction("Index");
            
            
        }

        public IActionResult RemoveSkateboardSlot(int skateboardId)
        {
            var user = _dbService.GetOneUser(email);
            _dbService.RemoveSkateboardSlot(skateboardId);
            return RedirectToAction("Index");

        }

        public User GetCurrentUser()
        {
            //string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            //string email = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email).Value;
            //var email = User.FindFirst("email")?.Value;
            var user = _dbService.GetOneUser(email);
            return user;
        }
    }
}
