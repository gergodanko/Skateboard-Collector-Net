using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkateboardCollector.Domain;
using SkateboardCollector.Services;

namespace SkateboardCollector.Controllers
{
    public class SkateboardsController : Controller
    {
        private readonly IDataBaseService _dbService;
        public static List<LikeList> likeLists;
        public SkateboardsController(IDataBaseService dbService)
        {
            _dbService = dbService;

        }
        public IActionResult Skateboards()
        {
            return View(GetSkateboards());
        }
        public List<LikeList> GetSkateboards()
        {
            likeLists= _dbService.GetLikeListForBoards();
            return _dbService.GetLikeListForBoards();
        }
        /// <summary>
        /// Returns false if the user has already liked the skateboard
        /// </summary>
        /// <param name="skateboardId"></param>
        /// <returns></returns>
        public bool checkLike(int skateboardId,int userId)
        {
            
            foreach(LikeList like in likeLists)
            {
                if (like.LikeSkateboard.SkateboardId.Equals(skateboardId))
                {
                    if (like.LikeUsers.Contains(userId))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public IActionResult GiveALike(int skateboardId)
        {
            ProfileController profileController = new ProfileController(_dbService);
            int currentUserId = profileController.GetCurrentUser().UserId;
            if (checkLike(skateboardId, currentUserId).Equals(false))
            {
                return RedirectToAction("Skateboards");
            }
            else
            {
                _dbService.GiveALike(currentUserId, skateboardId);
                return RedirectToAction("Skateboards");
            }
        }

    }
}
