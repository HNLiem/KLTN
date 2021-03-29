using MediatR;

namespace WebApi.Commands.Users.DeleteUser
{
    public class DeleteUser : IRequest
    {
        public int Id { get; }

        public DeleteUser(int id)
        {
            Id = id;
        }
    }
}
