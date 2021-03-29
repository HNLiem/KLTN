using System.Collections.Generic;
using WebApi.Commands.Auth.Login.Models;

namespace WebApi.Commands.Auth.Register.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}