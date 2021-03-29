using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Commands.Users.ChangePassword;
using WebApi.Commands.Users.ChangePassword.Models;
using WebApi.Commands.Users.Models.PatchUpdateUser;
using WebApi.Commands.Users.PatchUpdateUser;
using WebApi.Commands.Users.UpdateUser;
using WebApi.Commands.Users.UpdateUser.Models;
using WebApi.Queries.Users.GetUserById;
using Microsoft.AspNetCore.Http;
using WebApi.Commands.Users.CrateAvatar;
using WebApi.Commands.Users.UpdateSasAvatar;
using System.IO;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/v1/account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
  
        private IServiceProvider _serviceProvider;
        private IMediator _mediator;
    
       
        public AccountController(IServiceProvider serviceProvider, IMediator mediator)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentAccount()
        {
            var identity = (HttpContext.User.Identity as ClaimsIdentity).Name;
            int currentUserId = int.Parse(identity);

            var request = new GetUserById(currentUserId);
            var validator = (IValidator<GetUserById>)_serviceProvider.GetService(typeof(IValidator<GetUserById>));

            try
            {
                await validator.ValidateAndThrowAsync(request);
                var user = await _mediator.Send(request);

                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangeCurrentPassword([FromBody] ChangePasswordModel model)
        {
            var identity = (HttpContext.User.Identity as ClaimsIdentity).Name;
            int currentUserId = int.Parse(identity);

            var request = new ChangePassword(currentUserId, model);
            var validator = (IValidator<ChangePassword>)_serviceProvider.GetService(typeof(IValidator<ChangePassword>));

            try
            {
                await validator.ValidateAndThrowAsync(request);
                await _mediator.Send(request);

                return Ok();

            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCurrentAccount([FromBody]UpdateUserModel model)
        {
            var identity = (HttpContext.User.Identity as ClaimsIdentity).Name;
            int currentUserId = int.Parse(identity);

            var request = new UpdateUser(currentUserId, model);
            var validator = (IValidator<UpdateUser>)_serviceProvider.GetService(typeof(IValidator<UpdateUser>));

            try
            {
                await validator.ValidateAndThrowAsync(request);
                await _mediator.Send(request);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

    }      
}
