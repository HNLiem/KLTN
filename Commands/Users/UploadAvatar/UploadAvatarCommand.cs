using MediatR;
using Microsoft.AspNetCore.Http;
using System.IO;
using WebApi.Commands.Users.UploadAvatar.Models;

namespace WebApi.Commands.Users.CrateAvatar
{
    public class UploadAvatarCommand : IRequest<AvatarModel>
    {
        public int UserId { get; }
        public IFormFile FormFile { get; }
        public UploadAvatarCommand(int userId, IFormFile formFile)
        {
            UserId = userId;
            FormFile = formFile;
        }
    }
}
