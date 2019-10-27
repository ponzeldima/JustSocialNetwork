using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models.Conversations;
using SocialNetwork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Controllers
{
    public class ConversationsController : Controller
    {
        private readonly IMessagesGetter _messagesGetter;
        private readonly IUsersGetter _usersGetter;
        private readonly IConversationsGetter _conversationsGetter;
        public ConversationsController(IMessagesGetter messagesGetter, 
            IConversationsGetter conversationsGetter, IUsersGetter usersGetter)
        {
            _messagesGetter = messagesGetter;
            _conversationsGetter = conversationsGetter;
            _usersGetter = usersGetter;
        }

        [Authorize]
        public ViewResult Dialogue()
        {
            ConversationsDialogueViewModel obj = new ConversationsDialogueViewModel();
            User user = _usersGetter.GetForUserName(User.Identity.Name);
            obj.dialogue = (Dialogue)_conversationsGetter.GetForId(user.Conversations.FirstOrDefault().Conversation.Id);
            return View(obj);
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            return Content($"не аутентифицирован {User} - " +
                $"{User.Identity.Name} - {User.Identity.IsAuthenticated}");
        }
    }
}