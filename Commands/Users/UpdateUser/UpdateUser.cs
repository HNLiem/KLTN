using MediatR;
using WebApi.Commands.Users.UpdateUser.Models;

namespace WebApi.Commands.Users.UpdateUser
{
    public class UpdateUser : IRequest
    {
        public int Id { get; }
        public UpdateUserModel Model { get; }

        public UpdateUser(int id, UpdateUserModel model)
        {
            Id = id;
            Model = model;
        }
    }
}
