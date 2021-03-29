using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;

namespace WebApi.Queries.Users.GetUsers.Models
{
    public class GetUsersResultModel
    {
        public List<UsersModel> Users { get; }
        public Pagination Pagination { get; }

        public GetUsersResultModel(List<UsersModel> users, Pagination pagination)
        {
            Users = users;
            Pagination = pagination;
        }
    }
}
