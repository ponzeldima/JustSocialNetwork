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

        public UsersController(IUsersGetter usersGetter, AppDBContent db)
        {
            _usersGetter = usersGetter;
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
            return View(obj);
        }

        [Authorize(Roles = "admin")]
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
