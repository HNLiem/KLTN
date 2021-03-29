using MediatR;
using WebApi.Commands.Users.ChangePassword.Models;

namespace WebApi.Commands.Users.ChangePassword
{
    public class ChangePassword : IRequest
    {
        public int Id { get; }
        public ChangePasswordModel Model { get; }

        public ChangePassword(int id, ChangePasswordModel model)
        {
            Id = id;
            Model = model;
        }
    }
}
