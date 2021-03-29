using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebApi.Models.PhoneNumbers;

namespace WebApi.Common
{
    public static class ValidatorUtil
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public static bool IsValidPhoneNumber(List<PhoneNumberModel> listPhone)
        {
            return listPhone.All(phone => Regex.IsMatch(phone.PhoneNumber, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"));
        }
    }
}
