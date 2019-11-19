using SocialNetwork.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.ViewModels;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.DB;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDBContent _db;
        private readonly IUsersGetter _usersGetter;
        private readonly IConversationsGetter _conversationsGetter;

        public UsersController(IUsersGetter usersGetter,
            IConversationsGetter conversationsGetter, AppDBContent db)
        {
            _usersGetter = usersGetter;
            _conversationsGetter = conversationsGetter;
            _db = db;
        }

        public ViewResult List()
        {
            return View(_usersGetter.AllUsers);
        }

        public IActionResult Profile(string id)
        {
            User user = _usersGetter.GetForId(id);
            var obj = new UserProfileViewModel();
            obj.UserId = user.Id;
            obj.Friends = _usersGetter.AllUsers.ToList();
            obj.User = user;
            obj.SenderId = _usersGetter.GetForUserName(User.Identity.Name).Id;
            obj.IsFollower = _usersGetter.UserFollowsUser(id, obj.SenderId);
            obj.IsReader = _usersGetter.UserFollowsUser(obj.SenderId, id);
            obj.IsFriend = obj.IsReader && obj.IsFollower;
            if (_conversationsGetter.GetDialogueForUsers(user.Id, obj.SenderId) is null)
                obj.DialogueId = null;
            else
                obj.DialogueId = _conversationsGetter.GetDialogueForUsers(user.Id, obj.SenderId).Id;

            return View(obj);
        }

        public IActionResult AllUsers()
        {
            var users = _usersGetter.AllUsers;
            IEnumerable<User> result = users.Where(u => u.UserName != User.Identity.Name).ToList();
            return View(result);
        }

        public UserIdentifiersViewModel GetUserIdentifiers()
        {
            User user = _usersGetter.GetForUserName(User.Identity.Name);
            UserIdentifiersViewModel obj = new UserIdentifiersViewModel();
            obj.UserId = user.Id;
            obj.UserImagePath = user.Images.FirstOrDefault(i => i.IsAva).Path;
            return obj;
        }
    }
}
