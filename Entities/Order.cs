using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Common;

namespace WebApi.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public int Id { get; set; }
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
}
