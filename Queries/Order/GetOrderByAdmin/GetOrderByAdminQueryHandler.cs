using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Queries.Order.GetOrderByAdmin.Models;
using WebApi.Entities;

namespace WebApi.Queries.Order.GetOrderByAdmin
{
    public class GetOrderByAdminQueryHandler : IRequestHandler<GetOrderByAdminQuery, OrdersRepose>
    {
        private DataContext _context;
        private IMapper _mapper;
        public GetOrderByAdminQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OrdersRepose> Handle(GetOrderByAdminQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.Where(u => u.Id == request.Id)
                                          .FirstOrDefaultAsync();
                var wareHouse = await _context.Warehouses.Where(x => x.Address.Equals(user.Address)).ToListAsync();
                var orders = _mapper.Map<List<OrderRepose>>(wareHouse);
                for(int i=0; i< orders.Count(); i++)
                {
                    orders[i].WareHouseId = wareHouse[i].Id;
                }
                foreach(OrderRepose orderRepose in orders)
                {
                    if(! await _context.Orders.AnyAsync(x => x.WareHouseId.Equals(orderRepose.WareHouseId)))
                    {
                        var a = _mapper.Map<WebApi.Entities.Order>(orderRepose);
                        await _context.Orders.AddAsync(a);
                    }
                    
                }
                await _context.SaveChangesAsync();

                return new OrdersRepose
                {                  
                    Result = true,
                    Data = _mapper.Map<List<OrderRepose>>(orders)
                };
                 
            }
            catch(Exception ex)
            {
                return new OrdersRepose
                {
                    Message = ex.Message,
                    Result = false
                };
            }
               
        }
    }
}
