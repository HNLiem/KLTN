using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Common;

namespace WebApi.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avater { get; set; }
        public int UserId { get; set; }
        public EmployeeStatus Status { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public User User { get; set; }
    }
}
