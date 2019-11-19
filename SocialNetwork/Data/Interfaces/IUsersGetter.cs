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
        IEnumerable<User> GetFromConversation(Guid convId);
        User GetForId(string id);
        User GetForUserName(string userName);
        User GetForPhone(string phone);
        string GetUserNameByUserId(string userId);
        bool UserFollowsUser(string user1Id, string user2Id);
    }
}
