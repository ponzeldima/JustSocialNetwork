using SocialNetwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Interfaces
{
    public interface IUsersGetter
    {
        IEnumerable<User> AllUsers { get; }
        IEnumerable<User> GetFromConversation(int convId);
        User GetForId(int id);
        User GetForUserName(string userName);
        User GetForPhone(string phone);
    }
}
