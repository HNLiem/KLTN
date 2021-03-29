using System;
using System.Collections.Generic;
using WebApi.Models.PhoneNumbers;

namespace WebApi.Commands.Users.Models.PatchUpdateUser
{
    public class PatchUpdateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public List<PhoneNumberModel> UserPhoneNumbers { get; set; }
    }
}
