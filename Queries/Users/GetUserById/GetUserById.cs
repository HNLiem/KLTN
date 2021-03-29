using MediatR;
using WebApi.Queries.Users.GetUserById.Models;

namespace WebApi.Queries.Users.GetUserById
{
    public class GetUserById : IRequest<GetUserModel>
    {
        public int Id { get; }

        public GetUserById(int id)
        {
            Id = id;
        }
    }
}
