using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Queries.Users.GetUsers.Models;

namespace WebApi.Queries.Users.GetUsers
{
    public class GetUsersHanlder : IRequestHandler<GetUsers, GetUsersResultModel>
    {
        private DataContext _context;
        private IMapper _mapper;

        public GetUsersHanlder(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUsersResultModel> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var user = _context.Users.Include(p => p.UserPhoneNumbers).AsQueryable().Where(r => r.Role == Role.User);
            
            if (!string.IsNullOrEmpty(request.Sort.SortBy))
            {
                user = IQueryableExpressions<User>.Sort(user, request.Sort);
            }

            if (!string.IsNullOrEmpty(request.Search.SearchBy) && !string.IsNullOrEmpty(request.Search.KeyWord))
            {
                user = IQueryableExpressions<User>.Search(user, request.Search);
            }

            var users = await PagedList<User>.ToPagedList(user, request.PaginationParameters.PageNumber, request.PaginationParameters.PageSize);

            var model = _mapper.Map<List<UsersModel>>(user);

            var result = new GetUsersResultModel(model, users.Pagination);

            return result;
                   
        }
    }
}
