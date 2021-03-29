using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Commands.Users.UploadAvatar.Models;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Commands.Users.CrateAvatar
{
    public class UploadAvatarCommandHandler : IRequestHandler<UploadAvatarCommand, AvatarModel>
    {

        private IStorageService _storageService;
        private DataContext _context;
        public UploadAvatarCommandHandler(IStorageService storageService, DataContext data)
        {
            _context = data;
            _storageService = storageService;
        }

        public async Task<AvatarModel> Handle(UploadAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(u => u.Id == request.UserId)
                                           .FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(user.Avatar))
            {
                string filePathDelete = $"users/{request.UserId}/{user.Avatar}";
                await _storageService.DeleteBlob(filePathDelete, "images");
            }

            string name = "avatar" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            string filePath = $"users/{request.UserId}/{name}";

            await _storageService.UploadBlob(filePath, request.FormFile.OpenReadStream(), "images", "image/png");
            user.Avatar = name;
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
            return new AvatarModel(name);
        }
    }

}
