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
    [Authorize]
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

        public ViewResult Dialogue()
        {
            ConversationsDialogueViewModel obj = new ConversationsDialogueViewModel();
            User user = _usersGetter.GetForUserName(User.Identity.Name);
            obj.dialogue = (Dialogue)_conversationsGetter.GetForId(user.Conversations.FirstOrDefault().Conversation.Id);
            return View(obj);
        }

        public ViewResult List()
        {
            ConversationsListViewModel obj = new ConversationsListViewModel();
            var user = _usersGetter.GetForUserName(User.Identity.Name);
            var conversations = _conversationsGetter.GetFromUser(User.Identity.Name);

            IEnumerable<Conversation> result = conversations.
                Select(c => _conversationsGetter.GetForId(c.Id));

            result.Where(c => c is Dialogue).ToList()
                .ForEach(c => c.Name = c.Members.Select(uc => uc.User)
                .Where(u => u.UserName != user.UserName).FirstOrDefault()?.FirstName);

            result.Where(c => c is Dialogue).ToList()
                .ForEach(c => c.Image = c.Members.Select(uc => uc.User)
                .Where(u => u.UserName != user.UserName).FirstOrDefault()?.Image);
            obj.conversations = result;
            obj.user = user;
            return View(obj);
        }
    }
}