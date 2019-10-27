using SocialNetwork.Data.Models.Conversations;
using SocialNetwork.Data.Models.Messages;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }

        public string Image { get; set; }
        public List<UserConversation> Conversations { get; set; }
        public List<Message> Messages { get; set; }

        public User() : base()
        {
            Conversations = new List<UserConversation>();
            Messages = new List<Message>();
        }
        public User(string firstName, string lastName, string userName, string password) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }
    }
}
