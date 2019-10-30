using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models.Messages
{
    public abstract class Message : IMessageActions
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public DateTime SendTime { get; set; }
        public Message() { }
        public Message(User sender, Conversation conversation)
        {
            Sender = sender;
            Conversation = conversation;
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IMessageActions Edit()
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
