using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Commands.Auth.Register.Models;
using MediatR;
using WebApi.Commands.Auth.Register;
using WebApi.Commands.Auth.Login;
using WebApi.Commands.Auth.Login.Models;
using FluentValidation;

namespace WebApi.Controllers
{
 
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public AuthController(
            IMediator mediator,
            IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]LoginModel model)
        {
            var request = new Login(model);
            var validator = (IValidator<Login>)_serviceProvider.GetService(typeof(IValidator<Login>));

            try
            {
                await validator.ValidateAndThrowAsync(request);
                var token = await _mediator.Send(request);

                return Ok(token);

            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            await _mediator.Send(new Register(model));
            return Ok();
        }      
    }
}
