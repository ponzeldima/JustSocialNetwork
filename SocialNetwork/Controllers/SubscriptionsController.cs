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
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class SubscriptionsController : Controller
    {
        private readonly AppDBContent _db;
        private readonly IUsersGetter _usersGetter;
        private readonly IConversationsGetter _conversationsGetter;

        public SubscriptionsController(IUsersGetter usersGetter, 
            IConversationsGetter conversationsGetter, AppDBContent db)
        {
            _usersGetter = usersGetter;
            _conversationsGetter = conversationsGetter;
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
            var obj = new List<SubscriptionsFriendsViewModel>();
            User user = _db.Users
                .Include(u => u.Readers)
                    .ThenInclude(uu => uu.Reader)
                        .ThenInclude(r => r.Images)
                .Include(u => u.Followers)
                    .ThenInclude(uu => uu.Follower)
                        .ThenInclude(f => f.Images)
                .Include(u => u.Images)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            foreach (User friend in user.Friends)
            {
                var temp = new SubscriptionsFriendsViewModel()
                {
                    UserId = user.Id,
                    FriendId = friend.Id,
                    FriendAvaPath = friend.AvaImage.Path,
                    FriendName = friend.UserName,
                    FriendFirstName = friend.FirstName,
                    FriendLastName = friend.LastName
                };

                if (_conversationsGetter.GetDialogueForUsers(user.Id, friend.Id) is null)
                    temp.DialogueId = null;
                else
                    temp.DialogueId = _conversationsGetter.GetDialogueForUsers(user.Id, friend.Id).Id;

                obj.Add(temp);
            }
            return View(obj);
        }
    }
}