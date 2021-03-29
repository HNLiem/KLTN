using MediatR;
using WebApi.Commands.Users.UpdateSasAvatar.Models;

namespace WebApi.Commands.Users.UpdateSasAvatar
{
    public class UpdateSasAvatarCommand : IRequest<UriSas>
    {
        public int UserId { get; }
        public UpdateSasAvatarCommand(int userId)
        {
            UserId = userId;
        }
    }
}
