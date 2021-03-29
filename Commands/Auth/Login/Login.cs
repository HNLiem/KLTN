using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Commands.Auth.Login.Models;

namespace WebApi.Commands.Auth.Login
{
    public class Login : IRequest<LoginResultModel>
    {
        public LoginModel Model { get; }

        public Login(LoginModel model)
        {
            Model = model;
        }
    }
}
