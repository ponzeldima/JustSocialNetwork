using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Conversations;
using SocialNetwork.Data.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Mocks
{
    public class MockMessages : IMessagesGetter
    {
        private readonly IUsersGetter _users = new MockUsers();
        private readonly IConversationsGetter _conversations = new MockConversations();

        public IEnumerable<Message> AllMessges => new List<Message>
        {
            new TextMessage(_users.AllUsers.ToList()[0], _conversations.AllConversations.ToList()[0], "Hello)"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "Hi!"),
            new TextMessage(_users.AllUsers.ToList()[0], _conversations.AllConversations.ToList()[0], "How are you?"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "I`m OK. And you?!"),
            new TextMessage(_users.AllUsers.ToList()[0], _conversations.AllConversations.ToList()[0], "I am too"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "dads"),
            new TextMessage(_users.AllUsers.ToList()[0], _conversations.AllConversations.ToList()[0], "qweqwedsa asdcscd"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "asdca d"),
            new TextMessage(_users.AllUsers.ToList()[0], _conversations.AllConversations.ToList()[0], "sdasdf"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "I am Misha!"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "I am Mishaaaaa!"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "I am Mishaaaaaaaaa!"),
            new TextMessage(_users.AllUsers.ToList()[1], _conversations.AllConversations.ToList()[0], "I am Mishaaaaaaaaaaaaaaa!")
        };
        

        public IEnumerable<Message> GetFromConversation(int ConvId)
        {
            var res = new List<Message>();
            foreach (Message message in AllMessges)
            {
                if (message.Conversation.Id == ConvId)
                    res.Add(message);
            }
            return res;
        }
        public Message GetForId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetForSubstring(string substring)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetFromUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserMessage> GetNotReadedForUserAndConversation(string userId, int conversationId)
        {
            throw new NotImplementedException();
        }
    }
}
