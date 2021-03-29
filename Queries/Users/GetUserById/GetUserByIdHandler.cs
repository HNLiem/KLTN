using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Queries.Users.GetUserById.Models;

namespace WebApi.Queries.Users.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, GetUserModel>
    {
        private DataContext _context;
        private IMapper _mapper;
        public GetUserByIdHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserModel> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(u => u.UserPhoneNumbers)
                                          .Where(u => u.Id == request.Id)
                                          .FirstOrDefaultAsync();

            return _mapper.Map<GetUserModel>(user);
        }
    }
}
