using SocialNetwork.Data.Models.Conversations;
using SocialNetwork.Data.Models.Messages;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string Image { get; set; }
        public List<UserConversation> Conversations { get; set; }
        public List<Message> Messages { get; set; }
        public List<UserMessage> VisibleMessages { get; set; }

        public User() : base()
        {
            Conversations = new List<UserConversation>();
            Messages = new List<Message>();
            VisibleMessages = new List<UserMessage>();
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
