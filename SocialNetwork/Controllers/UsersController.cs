using SocialNetwork.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.ViewModels;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersGetter _usersGetter;

        public UsersController(IUsersGetter usersGetter)
        {
            _usersGetter = usersGetter;
        }

        public ViewResult List()
        {
            return View(_usersGetter.AllUsers);
        }

        public UserIdentifiersViewModel GetUserIdentifiers()
        {
            User user = _usersGetter.GetForUserName(User.Identity.Name);
            UserIdentifiersViewModel obj = new UserIdentifiersViewModel();
            obj.Image = user.Image;
            return obj;
        }
    }
}
