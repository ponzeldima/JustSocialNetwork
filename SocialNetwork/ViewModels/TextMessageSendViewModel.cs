using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class TextMessageSendViewModel
    {
        public string text { get; set; }
        public Guid conversationId { get; set; }
    }
}
