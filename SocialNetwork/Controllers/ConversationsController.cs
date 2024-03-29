﻿using System;
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
        public  IActionResult Dialogue(Guid id)
        {
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            ConversationsDialogueViewModel obj = new ConversationsDialogueViewModel();
            var user = _usersGetter.GetForUserName(User.Identity.Name); 
            Conversation conversation = _conversationsGetter.GetForId(id);
            conversation.Messages = conversation.Messages.OrderBy(m => m.SendTime).ToList();
            obj.user = user;
            obj.conversation = conversation;
            obj.notReadedMessages = _messagesGetter.GetNotReadForUserAndConversation(user.Id, id)
                .Select(um => um.Message);
            obj.notReadedMessagesForAnotherUser = _messagesGetter.GetNotReadForAnotherUserInConversation(user.Id, conversation.Id);

            return View(obj);
        }

        [HttpPost]
        public JsonResult ReadMessages([FromBody]MessageReadViewModel model)
        {
            var notReadedMessages = _messagesGetter.GetNotReadForUserAndConversation(model.userId, model.conversationId)
                .Select(um => um.Message);
            using (_db)
            {
                var notReadedMessagesForUser = _db.UserMessages.ToList();
                notReadedMessagesForUser = notReadedMessagesForUser
                    .Where(um => um.UserId == model.userId && notReadedMessages.Any(m => m.Id == um.MessageId)).ToList();
                notReadedMessagesForUser
                    .ForEach(um => um.IsRead = true);
                _db.SaveChanges();
            }

            return Json("Ok");
        }

        [HttpPost]
        public JsonResult SendMessage([FromBody]TextMessageSendViewModel model)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (ModelState.IsValid)
            {
                if (!(model.text is null)&& model.text.Trim() != "")
                {
                    User user = _usersGetter.GetForUserName(User.Identity.Name);
                    Conversation conversation = _conversationsGetter.GetForId(model.conversationId );
                    TextMessage message = new TextMessage(user, conversation, model.text);
                    using (_db)
                    {
                        _db.Messages.Add(message);
                        _db.SaveChanges();
                        foreach (string userId in conversation.Members.Select(um => um.UserId))
                        {
                            if (userId != user.Id)
                                message.VisibleFor.Add(new UserMessage { UserId = userId, MessageId = message.Id });
                        }
                        message.VisibleFor.Add(new UserMessage { UserId = user.Id, MessageId = message.Id, IsRead = true });

                        _db.SaveChanges(); // аутентификация

                    }

                    return Json("Ok");
                }
                ModelState.AddModelError("", "Порожнє повідомлення");
            }
            return Json("Error");
        }

        public ViewResult List()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

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
                .Where(u => u.UserName != user.UserName).FirstOrDefault()?.AvaImage);

            var dictionary = new Dictionary<Conversation, int>();
            foreach (Conversation conv in result)
            {
                dictionary.Add(conv, _messagesGetter.GetNotReadForUserAndConversation(user.Id, conv.Id).Count());
            }

            obj.conversations = dictionary;
            obj.user = user;
            return View(obj);
        }

        public int GetNotReadConversationsCount()
        {
            var user = _usersGetter.GetForUserName(User.Identity.Name);

            int notReadConversationsCount = _conversationsGetter.GetNotReadForUser(user.Id).Count();
            return notReadConversationsCount;
        } 
    }
}