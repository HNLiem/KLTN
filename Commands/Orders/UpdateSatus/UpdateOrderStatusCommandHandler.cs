using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Commands.Orders.UpdateSatus
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, BaseResponse>
    {
        private DataContext _context;
        public UpdateOrderStatusCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _context.Orders.Where(x => x.Id.Equals(request.OrderId)).FirstOrDefaultAsync();
                order.StatusOrder = request.Status;

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                return new BaseResponse
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }
    }
}
