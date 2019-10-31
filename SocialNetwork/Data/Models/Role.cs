using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Role : IdentityRole
    {
        public List<User> Users { get; set; }
        public Role() : base()
        {
            Users = new List<User>();
        }

        public Role(string name) : this()
        {
            Name = name;
        }
    }
}
