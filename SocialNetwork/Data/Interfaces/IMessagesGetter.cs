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
        IEnumerable<Message> GetFromConversation (Guid ConvId); 
        IEnumerable<Message> GetFromUser(int UserId);
        Message GetForId(Guid id);
        IEnumerable<Message> GetForSubstring(string substring);
        IEnumerable<UserMessage> GetNotReadForUserAndConversation(string userId, Guid conversationId);
        IEnumerable<Message> GetNotReadForAnotherUserInConversation(string userId, Guid conversationId);

    }
}
