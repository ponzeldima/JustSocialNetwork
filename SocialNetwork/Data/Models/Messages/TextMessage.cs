using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models.Messages
{
    public class TextMessage : Message
    {
        public string Text { get;  set; }
        public TextMessage() {}
        public TextMessage(User sender, Conversation conversation, string text) : base(sender, conversation)
        {
            Text = text;
        }

    }
}
