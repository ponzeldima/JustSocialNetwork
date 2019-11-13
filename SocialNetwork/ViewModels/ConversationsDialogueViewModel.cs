using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Conversations;
using SocialNetwork.Data.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class ConversationsDialogueViewModel
    {
        public Dialogue dialogue { get; set; }
        public IEnumerable<Message> notReadedMessages { get; set; }
        public IEnumerable<Message> notReadedMessagesForAnotherUser { get; set; }
        public User user { get; set; }
        public string text { get; set; }
    }
}
