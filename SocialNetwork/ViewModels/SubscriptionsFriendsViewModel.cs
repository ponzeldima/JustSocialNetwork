using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class SubscriptionsFriendsViewModel
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string FriendFirstName { get; set; }
        public string FriendLastName { get; set; }
        public string FriendName { get; set; }
        public Guid? DialogueId { get; set; }
        public string FriendAvaPath { get; set; }
    }
}
