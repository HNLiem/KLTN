using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Commands.Users.Models.PatchUpdateUser;
using WebApi.Helpers;

namespace WebApi.Commands.Users.PatchUpdateUser
{
    public class PatchUpdateUserHandler : IRequestHandler<PatchUpdateUser>
    {

        private DataContext _context;
        private IMapper _mapper;

        public PatchUpdateUserHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(PatchUpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(u => u.UserPhoneNumbers).Where(u => u.Id == request.Id).FirstOrDefaultAsync();
            var model = _mapper.Map<PatchUpdateUserModel>(user);

            request.JsonPatchDocument.ApplyTo(model);
            _mapper.Map(model, user);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
