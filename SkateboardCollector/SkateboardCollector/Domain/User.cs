using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SkateboardCollector.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserNickname { get; set; }
        public string UserPw { get; set; }

        
        public User(int id, string email, string nickname, string password)
        {
            UserId = id;
            UserEmail = email;
            UserNickname = nickname;
            UserPw = password;
        }

    }
}
