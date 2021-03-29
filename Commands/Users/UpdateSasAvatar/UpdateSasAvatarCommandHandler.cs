using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Commands.Users.UpdateSasAvatar.Models;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Commands.Users.UpdateSasAvatar
{
    public class UpdateSasAvatarCommandHandler : IRequestHandler<UpdateSasAvatarCommand, UriSas>
    {
        private IStorageService _storageService;
        private DataContext _context;

        public UpdateSasAvatarCommandHandler(DataContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<UriSas> Handle(UpdateSasAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(u => u.Id == request.UserId)
                                           .FirstOrDefaultAsync();

            string name = "avatar" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";         
            string filePath = $"users/{request.UserId}/{name}";          
            var uri = await _storageService.GetSAS(filePath, "images");

            if (!string.IsNullOrEmpty(user.Avatar))
            {
                string filePathDelete = $"users/{request.UserId}/{user.Avatar}";
                await _storageService.DeleteBlob(filePathDelete, "images");
            }

            user.Avatar = name;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new UriSas(uri, name);
        }
    }
}
