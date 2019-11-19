using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data.DB;
using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class SubscriptionsController : Controller
    {
        private readonly AppDBContent _db;
        private readonly IUsersGetter _usersGetter;

        public SubscriptionsController(IUsersGetter usersGetter, AppDBContent db)
        {
            _usersGetter = usersGetter;
            _db = db;
        }

        public JsonResult Subscribe([FromBody]string userId)
        {
            User reader = _db.Users.Include(u => u.Followers).ThenInclude(uu => uu.Follower)
                .FirstOrDefault(u => u.Id == userId);
            User follower = _db.Users.Include(u => u.Readers).ThenInclude(uu => uu.Reader)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (reader is null || follower is null)
                throw new Exception("reader or follower is null");
            if (follower.Readers.Any(r => r.ReaderId == reader.Id))
                throw new Exception("already subscribe on this user");
            if (follower.Id == reader.Id)
                throw new Exception("you can't subscribe on yourself");
            reader.Followers.Add(new UserUser() { ReaderId = reader.Id, FollowerId = follower.Id});
            _db.SaveChanges();

            return Json("Ok");
        }

        public ViewResult Readers()
        {
            User user = _db.Users
                .Include(u => u.Readers)
                    .ThenInclude(uu => uu.Reader)
                        .ThenInclude(r => r.Images)
                .Include(u => u.Images)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            return View(user);
        }

        public ViewResult Followers()
        {
            User user = _db.Users
                .Include(u => u.Followers)
                    .ThenInclude(uu => uu.Follower)
                        .ThenInclude(f => f.Images)
                .Include(u => u.Images)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            return View(user);
        }

        public ViewResult Friends()
        {
            User user = _db.Users
                .Include(u => u.Readers)
                    .ThenInclude(uu => uu.Reader)
                        .ThenInclude(r => r.Images)
                .Include(u => u.Followers)
                    .ThenInclude(uu => uu.Follower)
                        .ThenInclude(f => f.Images)
                .Include(u => u.Images)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            return View(user);
        }
    }
}