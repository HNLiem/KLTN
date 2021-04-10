using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Queries.Users.GetUserById;
using Microsoft.AspNetCore.Http;
using WebApi.Queries.Order.GetOrderByAdmin;
using Microsoft.AspNetCore.Authorization;
using WebApi.Common;
using WebApi.Commands.Orders.UpdateSatus;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public OrderController(IMediator mediator, IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {

            var identity = (HttpContext.User.Identity as ClaimsIdentity).Name;
            int currentUserId = int.Parse(identity);

            var request = new GetOrderByAdminQuery(currentUserId);
            var validator = (IValidator<GetOrderByAdminQuery>)_serviceProvider.GetService(typeof(IValidator<GetOrderByAdminQuery>));

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, StatusOrder status)
        {
            var identity = (HttpContext.User.Identity as ClaimsIdentity).Name;
            int currentUserId = int.Parse(identity);

            var request = new UpdateOrderStatusCommand(currentUserId, id, status);
            var validator = (IValidator<UpdateOrderStatusCommand>)_serviceProvider.GetService(typeof(IValidator<UpdateOrderStatusCommand>));

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
