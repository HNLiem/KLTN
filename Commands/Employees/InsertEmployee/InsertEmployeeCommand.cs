
using MediatR;
using WebApi.Commands.Employees.InsertEmployee.Models;
using WebApi.Entities;

namespace WebApi.Commands.Employees.InsertEmployee
{
    public class InsertEmployeeCommand :IRequest<BaseResponse>
    {
        public InsertEmployeeModel Model { get; }
        public int Id { get; }
        public InsertEmployeeCommand(int id, InsertEmployeeModel model)
        {
            Id = id;
            Model = model;
        }
    }
}
