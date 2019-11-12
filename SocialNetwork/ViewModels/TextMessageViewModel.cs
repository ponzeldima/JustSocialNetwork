using SocialNetwork.Data.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class TextMessageViewModel
    {
        public bool isUserMessage { get; set; }
        public bool isRead { get; set; }
        public bool isReadForAnotherUsers { get; set; }
        public TextMessage message { get; set; }
    }
}
