using SocialNetwork.Data.DB;
using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Data.Repositories
{
    public class MessagesRepository : IMessagesGetter
    {
        private readonly AppDBContent _appDBContent;
        public MessagesRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public IEnumerable<Message> AllMessges => _appDBContent.Messages.Include(m => m.Sender);

        public Message GetForId(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserMessage> GetNotReadForUserAndConversation(string userId, Guid conversationId)
        {
            var userMessages = _appDBContent.UserMessages.Include(um => um.Message);

            return userMessages.Where(um => um.UserId == userId)
                .Where(um => um.Message.ConversationId == conversationId)
                .Where(um => !um.IsRead)
                .Select(um => um);
        }


        public IEnumerable<Message> GetForSubstring(string substring)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetFromConversation(Guid ConvId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetFromUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetNotReadForAnotherUserInConversation(string userId, Guid conversationId)
        {
            var userMessages = _appDBContent.UserMessages.Include(um => um.Message);

            var messages = userMessages.Where(um => um.Message.ConversationId == conversationId && um.UserId != userId && !um.IsRead)
                .Select(um => um.Message).Distinct();

            List<Message> result = new List<Message>();

            foreach (Message message in messages)
            {
                if (userMessages.Where(um => um.MessageId == message.Id && um.UserId != userId).All(um => !um.IsRead))
                    result.Add(message);
            }

            return result;
        }
    }
}
