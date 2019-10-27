using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Interfaces
{
    public interface IMessageActions
    {
        void Send();
        void Delete();
        IMessageActions Edit();
    }
}
