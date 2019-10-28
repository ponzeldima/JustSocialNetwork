using SocialNetwork.Data.Models.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Interfaces
{
    public interface IConversationsGetter
    {
        IEnumerable<Conversation> AllConversations { get; }
        IEnumerable<Conversation> GetFromUser(string name);
        Conversation GetForId(int id); 
        Conversation GetForName(string name);
    }
}
