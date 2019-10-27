using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "No user name specified")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "No password specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
