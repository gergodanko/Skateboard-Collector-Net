using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkateboardCollector.Domain;
using SkateboardCollector.Services;
using System.Security.Claims;
namespace SkateboardCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly DataBaseService _dbService = new DataBaseService();

        public IActionResult Shop()
        {
            return View("Shop");
        }
        [HttpGet]
        [Route("GetAllDecks")]
        public List<Deck> GetAllDecks()
        {
            List<Deck> allDecks = _dbService.GetAllDecks();
            return allDecks;
        }
        [HttpGet]
        [Route("GetAllTrucks")]
        public List<Truck> GetAllTrucks()
        {
            List<Truck> allTrucks = _dbService.GetAllTrucks();
            return allTrucks;

        }
        [HttpGet]
        [Route("GetAllWheels")]
        public List<Wheels> GetAllWheels()
        {
            List<Wheels> allWheels = _dbService.GetAllWheels();
            return allWheels;

        }

        [HttpPost]
        [Route("UpdateBoard")]
        public void UpdateBoard([FromForm]int boardId,[FromForm]int hardwareId,[FromForm]string hardwareType)
        {
            _dbService.UpdateUserBoard(boardId, hardwareId, hardwareType);
        }

        [HttpGet]
        [Route("GetUserSkateboards")]
        public List<Skateboard> GetUserSkateboards()
        {
            ProfileController profileController = new ProfileController(_dbService);
            return _dbService.GetUserSkateboards(profileController.GetCurrentUser().UserId);
        }

    }
}
