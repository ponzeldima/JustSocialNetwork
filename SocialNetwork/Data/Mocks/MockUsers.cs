using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Mocks
{
    public class MockUsers : IUsersGetter
    {
        public IEnumerable<User> AllUsers => throw new NotImplementedException();

        public User GetForId(string id)
        {
            throw new NotImplementedException();
        }

        public User GetForUserName(string nickname)
        {
            throw new NotImplementedException();
        }

        public User GetForPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetFromConversation(Guid convId)
        {
            throw new NotImplementedException();
        }
    }
}
