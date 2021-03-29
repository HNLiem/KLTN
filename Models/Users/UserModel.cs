using System;
using System.Collections.Generic;
using WebApi.Models.PhoneNumbers;

namespace WebApi.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public List<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}