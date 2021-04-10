using MediatR;
using WebApi.Commands.Orders.UpdateSatus.Models;
using WebApi.Common;
using WebApi.Entities;

namespace WebApi.Commands.Orders.UpdateSatus
{
    public class UpdateOrderStatusCommand :IRequest<BaseResponse>
    {
        public int UserId { get; }
        public int OrderId { get; }
        public StatusOrder Status { get; }
        public UpdateOrderStatusCommand(int id, int orderId, StatusOrder status)
        {
            Status = status;
            UserId = id;
            OrderId = orderId;
        }
    }
}
