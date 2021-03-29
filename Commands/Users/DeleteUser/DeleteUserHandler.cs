using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Commands.Users.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        private DataContext _context;
        private IStorageService _storageService;

        public DeleteUserHandler(DataContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);

            string filePathDelete = $"users/{request.Id}";
            await _storageService.DeleteDirectory(filePathDelete, "images");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
