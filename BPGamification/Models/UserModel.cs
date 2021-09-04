using BPGamification.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPGamification.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public int? DivisionCode { get; set; }

        public User GetUser()
        {
            var user = new User();

            user.Email = Email;
            user.PasswordHash = Hash.GetHashStringInBase64(Password);
            user.Role = Role;
            user.FullName = FullName;
            user.DivisionCode = DivisionCode;


            return user;
        }
    }
}
