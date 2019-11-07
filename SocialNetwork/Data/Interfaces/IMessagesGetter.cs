using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Interfaces
{
    public interface IMessagesGetter
    {
        IEnumerable<Message> AllMessges { get; }
        IEnumerable<Message> GetFromConversation (int ConvId); 
        IEnumerable<Message> GetFromUser(int UserId);
        Message GetForId(int id);
        IEnumerable<Message> GetForSubstring(string substring);
        IEnumerable<UserMessage> GetNotReadedForUserAndConversation(string userId, int conversationId);

    }
}
