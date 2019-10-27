using SocialNetwork.Data.DB;
using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models.Conversations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    .ThenInclude(m => m.Sender);

        public Conversation GetForId(int id)
        {
            return AllConversations.FirstOrDefault(c => c.Id == id);
        }

        public Conversation GetForName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> GetFromUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
