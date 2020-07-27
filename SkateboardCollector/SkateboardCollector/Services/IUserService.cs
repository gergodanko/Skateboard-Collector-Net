using SkateboardCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Services
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetOne(string email);
        public User GetOne(int id);
        public User Login(string email, string password);

    }
}
