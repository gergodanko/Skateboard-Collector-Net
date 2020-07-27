using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkateboardCollector.Domain;
using SkateboardCollector.Services;

namespace SkateboardCollector.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly InMemoryUserService userService = new InMemoryUserService();
        public ActionResult Index()
        {
            var users = userService.GetAll();
            return View("Users",users);
        }

        [HttpGet]
        public List<User> All()
        {
            var users = userService.GetAll();
            return users;
        }
        /*public ActionResult Get(int id)
        {
            
            var user = userService.GetOne(id);
            return View(user);
        }*/
        
    }
}
