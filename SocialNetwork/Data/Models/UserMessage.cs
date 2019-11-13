using SocialNetwork.Data.Models.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class UserMessage
    {
        [Required]
        public Guid MessageId { get; set; }
        public Message Message { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public bool IsRead { get; set; }

        public UserMessage()
        {
            IsRead = false;
        }
    }
}
