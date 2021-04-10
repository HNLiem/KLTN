using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Commands.Employees.InsertEmployee;
using WebApi.Commands.Employees.InsertEmployee.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public EmployeeController(IMediator mediator, IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] InsertEmployeeModel model)
        {
            var identity = (HttpContext.User.Identity as ClaimsIdentity).Name;
            int currentUserId = int.Parse(identity);

            var request = new InsertEmployeeCommand(currentUserId, model);
            var validator = (IValidator<InsertEmployeeCommand>)_serviceProvider.GetService(typeof(IValidator<InsertEmployeeCommand>));

            try
            {
                await validator.ValidateAndThrowAsync(request);
                return Ok(await _mediator.Send(request));

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
