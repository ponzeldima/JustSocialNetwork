﻿using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Conversations;
using SocialNetwork.Data.Models.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.DB
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Roles.Any())
                content.Roles.AddRange(Roles.Select(u => u.Value));
            if (!content.Users.Any())
                content.Users.AddRange(Users.Select(u => u.Value));
            if (!content.Conversations.Any())
                content.Conversations.AddRange(Conversations.Select(c => c.Value));
            if (!content.Messages.Any())
                content.Messages.AddRange(Messages);

            //content.SaveChanges();


            User dima = Users["ponzel.dima35"];
            User misha = Users["povhmisha"];
            User slava = Users["yaroslavponzel"];

            Conversation m_d = Conversations["povhmisha - ponzel.dima35"];
            Conversation d_y = Conversations["ponzel.dima35 - yaroslavponzel"];

            dima.Conversations.Add(new UserConversation { UserId = dima.Id, ConversationId = m_d.Id });
            dima.Conversations.Add(new UserConversation { UserId = dima.Id, ConversationId = d_y.Id });
            misha.Conversations.Add(new UserConversation { UserId = misha.Id, ConversationId = m_d.Id });
            slava.Conversations.Add(new UserConversation { UserId = slava.Id, ConversationId = d_y.Id });
            content.SaveChanges();
        }

        public static Dictionary<string, Conversation> conversations;
        public static Dictionary<string, Conversation> Conversations
        {
            get
            {
                if (conversations is null)
                {
                    var list = new Conversation[]
                    {
                        new Dialogue(){ NickName = "povhmisha - ponzel.dima35" },
                        new Dialogue(){ NickName = "ponzel.dima35 - yaroslavponzel" }
                    };

                    conversations = new Dictionary<string, Conversation>();
                    foreach (Conversation conversation in list)
                        conversations.Add(conversation.NickName, conversation);
                }
                return conversations;
            }
        }

        public static Dictionary<string, Role> roles;
        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (roles is null)
                {
                    var list = new Role[]
                    {
                        new Role("user"),
                        new Role("admin")
                    };

                    roles = new Dictionary<string, Role>();
                    foreach (Role role in list)
                        roles.Add(role.Name, role);
                }
                return roles;
            }
        }

        public static List<Message> messages;
        public static List<Message> Messages
        {
            get
            {
                if (messages is null)
                {
                    var list = new Message[]
                    {
                        new TextMessage(Users["ponzel.dima35"], Conversations["povhmisha - ponzel.dima35"], "Hello)"){ SendTime = new DateTime(2019, 10, 30, 16, 2, 0)},
                        new TextMessage(Users["povhmisha"], Conversations["povhmisha - ponzel.dima35"], "Hi!"){ SendTime = new DateTime(2019, 10, 30, 16, 2, 30)},
                        new TextMessage(Users["ponzel.dima35"], Conversations["povhmisha - ponzel.dima35"], "How are you?"){ SendTime = new DateTime(2019, 10, 30, 16, 2, 45)},
                        new TextMessage(Users["povhmisha"], Conversations["povhmisha - ponzel.dima35"], "I`m OK. And you?!"){ SendTime = new DateTime(2019, 10, 30, 16, 3, 0)},
                        new TextMessage(Users["ponzel.dima35"], Conversations["povhmisha - ponzel.dima35"], "I am too"){ SendTime = new DateTime(2019, 10, 30, 16, 3, 10)},
                        new TextMessage(Users["povhmisha"], Conversations["povhmisha - ponzel.dima35"], "I am Misha!"){ SendTime = new DateTime(2019, 10, 30, 16, 3, 40)},
                        new TextMessage(Users["povhmisha"], Conversations["povhmisha - ponzel.dima35"], "I am Mishaaaa!"){ SendTime = new DateTime(2019, 10, 30, 16, 3, 50)},
                        new TextMessage(Users["povhmisha"], Conversations["povhmisha - ponzel.dima35"], "I am Mishaaaaaaaa!"){ SendTime = new DateTime(2019, 10, 30, 16, 3, 51)},
                        new TextMessage(Users["povhmisha"], Conversations["povhmisha - ponzel.dima35"], "I am Mishaaaaaaaaaaaaa!"){ SendTime = new DateTime(2019, 10, 30, 16, 3, 52)},
                        new TextMessage(Users["yaroslavponzel"], Conversations["ponzel.dima35 - yaroslavponzel"], "Zdorovichko!"){ SendTime = new DateTime(2019, 10, 30, 17, 2, 0)},
                        new TextMessage(Users["yaroslavponzel"], Conversations["ponzel.dima35 - yaroslavponzel"], "Zdorovichko!"){ SendTime = new DateTime(2019, 10, 30, 17, 4, 0)}
                    };

                    messages = new List<Message>();
                    foreach (Message message in list)
                        messages.Add(message);
                }
                return messages;
            }
        }

        public static Dictionary<string, User> users;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (users is null)
                {
                    var list = new User[]
                    {
                        new User("Dima", "Ponzel", "ponzel.dima35", "+380507854882") {
                            Image = "/image/Dima.jpg", Email = "ponzel.dima35@gmail.com",
                            Password = "1231231", Role = Roles["admin"]},
                        new User("Misha", "Povh", "povhmisha", "+380507854112") {
                            Image = "/image/Misha.jpg", Email = "povhmisha@gmail.com",
                            Password = "1", Role = Roles["admin"]},
                        new User("Slava", "Ponzel", "yaroslavponzel", "+380992276091") {
                            Image = "/image/Slava.jpg", Email = "yaroslavponzel@gmail.com",
                            Password = "1", Role = Roles["user"]}
                    };

                    users = new Dictionary<string, User>();
                    foreach (User user in list)
                        users.Add(user.UserName, user);
                }
                return users;
            }
        }
    }
}