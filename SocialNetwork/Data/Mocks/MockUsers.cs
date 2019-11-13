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
        public IEnumerable<User> AllUsers => new List<User> {
            new User("Dima", "Ponzel", "ponzel.dima35", "+380507854882"){ Image = "/image/Dima.jpg"},
            new User("Misha", "Povh", "povhmisha", "+380507854112"){ Image = "/image/Misha.jpg"},
            new User("Slava", "Ponzel", "yaroslavponzel", "+380992276091"){ Image = "/image/Slava.jpg"}
        };

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
