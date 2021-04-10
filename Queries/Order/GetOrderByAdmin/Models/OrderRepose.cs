using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.Entities;

namespace WebApi.Queries.Order.GetOrderByAdmin.Models
{
    public class OrderRepose
    {
        public int WareHouseId { get; set; }
        public DateTime SenderDate { get; set; }
        public string SenderName { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public DateTime ReceiverDate { get; set; }
        public string Nature { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    }

    public class OrdersRepose : BaseResponse
    {
        public List<OrderRepose> Data { get; set; }
    }
}
