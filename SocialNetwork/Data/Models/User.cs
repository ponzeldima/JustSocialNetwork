using SocialNetwork.Data.Models.Conversations;
using SocialNetwork.Data.Models.Messages;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime DayOfBirth { get; set; }
        [Required]
        public string Settlement { get; set; }

        [NotMapped]
        public Image AvaImage => Images.FirstOrDefault(i => i.IsAva);
        public List<Image> Images { get; set; }

        public List<UserConversation> Conversations { get; set; }
        public List<Message> Messages { get; set; }
        public List<UserMessage> VisibleMessages { get; set; }
        public List<User> SubscribedTo { get; set; }
        public List<User> Subscribers { get; set; }

        public User() : base()
        {
            Conversations = new List<UserConversation>();
            Messages = new List<Message>();
            VisibleMessages = new List<UserMessage>();
            Images = new List<Image>();
            SubscribedTo = new List<User>();
            Subscribers = new List<User>();
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
