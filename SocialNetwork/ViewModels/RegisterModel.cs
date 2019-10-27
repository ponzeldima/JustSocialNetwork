using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "No user name specified")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "No first name specified")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "No last name specified")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "No password specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wrong password")]
        public string ConfirmPassword { get; set; }
    }
}
