using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.Entities;
using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApi.Commands.Auth.Register
{
    public class RegisterHandler : IRequestHandler<Register>
    {
        private DataContext _dataContext;
        private IMapper _mapper;
        private IConfiguration _configuration;
        public RegisterHandler(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(Register request, CancellationToken cancellationToken)
        {
            var userCurrent = await _dataContext.Users.Where(u => u.Username == request.Model.Username)
                                                      .FirstOrDefaultAsync();
            if (userCurrent != null)
            {
                _dataContext.Users.Remove(userCurrent);
            }

            var user = _mapper.Map<User>(request.Model);
            user.Role = Role.User;
          

            byte[] passwordHash, passwordSalt;
            PasswordUtil.CreatePasswordHash(request.Model.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.IsActivated = true;

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
