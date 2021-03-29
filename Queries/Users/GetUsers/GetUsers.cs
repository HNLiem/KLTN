using MediatR;
using WebApi.Common;
using WebApi.Queries.Users.GetUsers.Models;

namespace WebApi.Queries.Users.GetUsers
{
    public class GetUsers : IRequest<GetUsersResultModel>
    {
        public PaginationParameters PaginationParameters { get; }
        public Sort Sort { get; }
        public Search Search { get; }

        public GetUsers(PaginationParameters paginationParameters, Sort sort, Search search)
        {
            Sort = sort;
            Search = search;
            PaginationParameters = paginationParameters;
        }
    }
}
