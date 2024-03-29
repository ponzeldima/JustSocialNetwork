﻿using SocialNetwork.Data.DB;
using SocialNetwork.Data.Interfaces;
using SocialNetwork.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Repositories
{
    public class UsersRepository : IUsersGetter
    {
        private readonly AppDBContent _appDBContent;
        public UsersRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public IEnumerable<User> AllUsers =>
            _appDBContent.Users
            .Include(u => u.Conversations)
                .ThenInclude(uc => uc.Conversation)
            .Include(u => u.Messages)
            .Include(u => u.Images);

        public User GetForId(string id)
        {
            return AllUsers.FirstOrDefault(u => u.Id == id);
        }

        public User GetForUserName(string name)
        {
            return AllUsers.FirstOrDefault(u => u.UserName == name);
        }

        public User GetForPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetFromConversation(Guid convId)
        {
            throw new NotImplementedException();
        }
    }
}
