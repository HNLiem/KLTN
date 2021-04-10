using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;

namespace WebApi.Commands.Orders.UpdateSatus.Models
{
    public class UpdateOrderStatusModel
    {
        public StatusOrder Status { get; set; }
    }
}
