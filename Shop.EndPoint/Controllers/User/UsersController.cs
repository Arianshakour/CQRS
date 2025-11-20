using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Dto.User;
using Shop.Application.Feature.User.Request.Command;
using Shop.Application.Feature.User.Request.Query;

namespace Shop.EndPoint.Controllers.User
{
    public class UsersController : BaseControllers
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("RegisterUser")]
        public ActionResult Register(CreateUserDto input)
        {
            var result = _mediator.Send(new RegisterUserRequest() { create = input });
            return Ok(result);
        }

        [HttpPost("LoginUser")]
        public IActionResult Login(UserDto input)
        {
            var result = _mediator.Send(new LoginUserRequest() { userDto = input });
            return Ok(result);
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult Update(Guid id, UpdateUserDto input)
        {
            var result = _mediator.Send(new UpdateUserRequest() 
            { 
                Id = id, // az route
                update = input //az body
            });
            return Ok(result);
        }
    }
}
