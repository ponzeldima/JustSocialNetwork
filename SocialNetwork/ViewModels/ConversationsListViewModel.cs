﻿using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class ConversationsListViewModel
    {
        public IEnumerable<Conversation> conversations { get; set; }
        public User user { get; set; }
    }
}
