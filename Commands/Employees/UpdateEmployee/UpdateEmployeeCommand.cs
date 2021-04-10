using MediatR;
using WebApi.Commands.Employees.UpdateEmployee.Models;
using WebApi.Entities;

namespace WebApi.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommand :IRequest<BaseResponse>
    {
        public UpdateEmployeeModel Model { get; }
        public int Id { get; }
        public string UserName { get; }
        public UpdateEmployeeCommand()
        {

        }
    }
}
