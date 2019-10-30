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
using SocialNetwork.Data.Models.Messages;
using SocialNetwork.Data.DB;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class ConversationsController : Controller
    {
        private readonly AppDBContent _db;
        private readonly IMessagesGetter _messagesGetter;
        private readonly IUsersGetter _usersGetter;
        private readonly IConversationsGetter _conversationsGetter;
        public ConversationsController(IMessagesGetter messagesGetter, 
            IConversationsGetter conversationsGetter, IUsersGetter usersGetter, AppDBContent db)
        {
            _messagesGetter = messagesGetter;
            _conversationsGetter = conversationsGetter;
            _usersGetter = usersGetter;
            _db = db;
        }

        [HttpGet]
        public IActionResult Dialogue(int id)
        {
            ConversationsDialogueViewModel obj = new ConversationsDialogueViewModel();
            obj.user = _usersGetter.GetForUserName(User.Identity.Name);
            Dialogue dialogue = (Dialogue)_conversationsGetter.GetForId(id);
            dialogue.Messages = dialogue.Messages.OrderBy(m => m.SendTime).ToList();
            obj.dialogue = dialogue;
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string text, int conversationId, string sendTime)
        {
            if (ModelState.IsValid)
            {
                
                if (text != "" && !(text is null))
                {
                    DateTime _sendTime = Convert.ToDateTime(sendTime);
                    User user = _usersGetter.GetForUserName(User.Identity.Name);
                    Conversation conversation = _conversationsGetter.GetForId(conversationId);
                    TextMessage message = new TextMessage(user, conversation, text) { SendTime = _sendTime};
                    _db.Messages.Add(message);

                    await _db.SaveChangesAsync(); // аутентификация

                    return RedirectToAction($"Dialogue/{conversationId}","Conversations");
                }
                ModelState.AddModelError("", "Порожнє повідомлення");
            }
            return RedirectToAction($"Dialogue/{conversationId}", "Conversations");
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