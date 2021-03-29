using MediatR;
using WebApi.Commands.Auth.Register.Models;

namespace WebApi.Commands.Auth.Register
{
    public class Register : IRequest
    {
        public RegisterModel Model { get; }

        public Register(RegisterModel model)
        {
            Model = model;
        }
    }
}
