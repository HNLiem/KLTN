using System;

namespace WebApi.Commands.Employees.UpdateEmployee.Models
{
    public class UpdateEmployeeModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
