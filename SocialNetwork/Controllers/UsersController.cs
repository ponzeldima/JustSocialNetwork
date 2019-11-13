using SocialNetwork.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.ViewModels;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.DB;

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

        public UserIdentifiersViewModel GetUserIdentifiers()
        {
            User user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            UserIdentifiersViewModel obj = new UserIdentifiersViewModel();
            obj.User = user;
            return obj;
        }
    }
}
