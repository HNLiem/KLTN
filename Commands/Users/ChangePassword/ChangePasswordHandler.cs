using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.Helpers;

namespace WebApi.Commands.Users.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePassword>
    {

        private DataContext _context;
        private IMapper _mapper;

        public ChangePasswordHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

            byte[] passwordHash, passwordSalt;
            PasswordUtil.CreatePasswordHash(request.Model.NewPassword, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
