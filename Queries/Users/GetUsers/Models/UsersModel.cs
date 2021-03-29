using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.PhoneNumbers;

namespace WebApi.Queries.Users.GetUsers.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avatar { get; set; }
        public List<PhoneNumberModel> UserPhoneNumbers { get; set; }
    }
}
