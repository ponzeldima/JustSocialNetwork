using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class UserUser
    {
        public string ReaderId { get; set; }
        public User Reader { get; set; }
        public string FollowerId { get; set; }
        public User Follower { get; set; }
        public DateTimeOffset SubscribedAt { get; set; }
    }
}
