
using SkateboardCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Services
{
    public interface IDataBaseService
    {
        public User Login(string email, string password);
        public User GetOneUser(string email);
        public List<User> GetAllUser();
        public List<Deck> GetAllDecks();
        public List<Truck> GetAllTrucks();
        public List<Wheels> GetAllWheels();
        public List<Skateboard> GetUserSkateboards(int userId);
        public void AddSkateboardSlot(int userId);
        public void RemoveSkateboardSlot(int skateboardId);
        public void RegisterUser(string nickname, string email, string password);
        public List<LikeList> GetLikeListForBoards();
        public void GiveALike(int userId, int skateboardId);
    }
}
