using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Commands.Auth.Login.Models
{
    public class LoginResultModel
    {
        public string TokenString { get; }

        public LoginResultModel(string tokenString)
        {
            TokenString = tokenString;
        }
    }
}
