using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardCollector.Domain
{
    public class LikeList
    {
        public List<int> LikeUsers { get; set; }
        public Skateboard LikeSkateboard { get; set; }
        public string LikeNickname { get; set; }

        public LikeList(List<int> user, Skateboard skateboard,string likeNickname)
        {
            LikeUsers = user;
            LikeSkateboard = skateboard;
            LikeNickname = likeNickname;
        }
    }
}
