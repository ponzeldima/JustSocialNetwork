using SocialNetwork.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersGetter _userGetter;

        public UsersController(IUsersGetter usersGetter)
        {
            _userGetter = usersGetter;
        }

        public ViewResult List()
        {
            return View(_userGetter.AllUsers);
        }
    }
}
