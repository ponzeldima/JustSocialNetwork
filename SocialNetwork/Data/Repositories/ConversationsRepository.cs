using SocialNetwork.Data.DB;
using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models.Conversations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Data.Repositories
{
    public class ConversationsRepository : IConversationsGetter
    {
        private readonly AppDBContent _appDBContent;
        public ConversationsRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public IEnumerable<Conversation> AllConversations =>
            _appDBContent.Conversations
                .Include(c => c.Members)
                .Include(c => c.Messages)
                    .ThenInclude(m => m.Sender)
                        .ThenInclude(u => u.Images);

        public Conversation GetForId(Guid id)
        {
            return AllConversations.FirstOrDefault(c => c.Id == id);
        }

        public Conversation GetForName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> GetFromUser(string name)
        {
            var users = _appDBContent.Users
                .Include(u => u.Messages)
                .Include(u => u.Conversations)
                    .ThenInclude(uc => uc.Conversation);

            var conversations = users.Where(u => u.UserName == name)
                .SelectMany(u => u.Conversations)
                .Select(uc => uc.Conversation);

            return conversations;
        }

        public IEnumerable<Conversation> GetNotReadForUser(string userId)
        {
            var userMessage = _appDBContent.UserMessages
                .Include(um => um.Message)
                    .ThenInclude(m => m.Conversation);

            var conversations = userMessage
                .Where(um => um.UserId == userId && !um.IsRead)
                .Select(um => um.Message)
                .Select(m => m.Conversation)
                .Distinct();

            return conversations;
        }
    }
}
