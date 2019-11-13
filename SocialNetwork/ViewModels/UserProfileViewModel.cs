using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class UserProfileViewModel
    {
        public User User { get; set; }
        public List<User> Friends { get; set; }
        public string UserId { get; set; }
    }
}
