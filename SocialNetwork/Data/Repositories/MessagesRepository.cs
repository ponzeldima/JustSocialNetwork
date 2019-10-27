using SocialNetwork.Data.DB;
using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Message GetForId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetForSubstring(string substring)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetFromConversation(int ConvId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetFromUser(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
