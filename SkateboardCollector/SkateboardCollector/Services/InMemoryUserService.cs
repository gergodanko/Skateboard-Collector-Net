using Microsoft.AspNetCore.Mvc.Routing;
using SkateboardCollector.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Services
{
    
    public class InMemoryUserService : IUserService
    {
        [Required]
        private List<User> _allUser = new List<User>();
        
        public InMemoryUserService()
        {
            
             DataBaseService dbService = new DataBaseService();
             _allUser = dbService.GetAllUser();
        }
        public List<User> GetAll()
        {
            return _allUser;
        }
        public User GetOne(int id)
        {
            return _allUser.Where(u => u.UserId == id).First();
        }
        public User GetOne(string email)
        {
            return _allUser.Where(u => u.UserEmail == email).First();
        }
        public User GetByUsernameAndPassword(User user)
        {
            return _allUser.Where(u => u.UserEmail == user.UserEmail & u.UserPw == user.UserPw).FirstOrDefault();
        }

        public User Login(string email, string password)
        {
            var user = GetOne(email);
            if(user == null)
            {
                return null;
            }
            else if (user.UserPw != password)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        
    }
}
