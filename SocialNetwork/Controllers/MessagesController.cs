using SocialNetwork.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessagesGetter _messagesGetter;
        private readonly IConversationsGetter _conversationsGetter;
        public MessagesController(IMessagesGetter messagesGetter, IConversationsGetter conversationsGetter)
        {
            _messagesGetter = messagesGetter;
            _conversationsGetter = conversationsGetter;
        }

        public ViewResult Dialog()
        {
            return View(_messagesGetter.AllMessges);
        }

        [Authorize(Roles = "admin")]
        public ViewResult AllMessages()
        {
            MessagesAllMessagesViewModel obj = new MessagesAllMessagesViewModel();
            obj.messages = _messagesGetter.AllMessges;
            return View(obj);
        }
    }
}
