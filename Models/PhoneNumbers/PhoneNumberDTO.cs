using System;
using System.Collections.Generic;
namespace WebApi.Models.PhoneNumbers
{
    public class PhoneNumberModel
    {
        public string PhoneNumber { get; set; }

        public PhoneNumberModel(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }

}
