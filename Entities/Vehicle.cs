using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Common;

namespace WebApi.Entities
{
    public class Vehicle :BaseResponse
    {
        [Required]
        public int Id { get; set; }
        public string LicensePlates { get; set; }
        public TypeVehicle Type { get; set; }
        public float ShippingVolume { get; set; }
        public Employee Employee { get; set; }
    }
}
