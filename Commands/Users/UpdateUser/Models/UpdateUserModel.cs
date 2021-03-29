using System;
using System.Collections.Generic;
using WebApi.Models.PhoneNumbers;

namespace WebApi.Commands.Users.UpdateUser.Models
{
    public class UpdateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public List<PhoneNumberModel> UserPhoneNumbers { get; set; }
    }
}
