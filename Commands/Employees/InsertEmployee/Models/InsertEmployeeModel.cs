using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Commands.Employees.InsertEmployee.Models
{
    public class InsertEmployeeModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Avater { get; set; }
    }
}
