using SocialNetwork.Data.Models.Conversations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsAva { get; set; }

        //public Guid ConversationId { get; set; }
        //public Conversation Conversation { get; set; }
    }
}
