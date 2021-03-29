using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Common;

namespace WebApi.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public bool IsActivated { get; set; }
        public ICollection<UserPhoneNumber> UserPhoneNumbers { get; set; }

    }
}