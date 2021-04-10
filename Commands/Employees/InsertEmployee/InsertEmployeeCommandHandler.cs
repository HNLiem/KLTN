using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Commands.Employees.InsertEmployee
{
    public class InsertEmployeeCommandHandler : IRequestHandler<InsertEmployeeCommand, BaseResponse>
    {
        private DataContext _context;
        private IMapper _mapper;
        public InsertEmployeeCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(InsertEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                var employee = _mapper.Map<Employee>(request.Model);

                employee.Status = Common.EmployeeStatus.Off;
                employee.UserId = user.Id;
                employee.IsDelete = false;

                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

                return new BaseResponse
                {
                    Result = true
                };

            }
            catch(Exception ex)
            {
                return new BaseResponse
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }
    }
}
