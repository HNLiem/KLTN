using MediatR;
using WebApi.Queries.Order.GetOrderByAdmin.Models;

namespace WebApi.Queries.Order.GetOrderByAdmin
{
    public class GetOrderByAdminQuery : IRequest<OrdersRepose>
    {
        public int Id { get; }

        public GetOrderByAdminQuery(int id)
        {
            Id = id;
        }
    }
}
