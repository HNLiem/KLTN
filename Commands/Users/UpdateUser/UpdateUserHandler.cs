using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace WebApi.Commands.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser>
    {
        private DataContext _dataContext;
        private IMapper _mapper;
        public UpdateUserHandler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.Include(u => u.UserPhoneNumbers).Where(u => u.Id == request.Id).FirstOrDefaultAsync();
            _mapper.Map(request.Model, user);

            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
