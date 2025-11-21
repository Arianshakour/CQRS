using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Dto.Cart;
using Shop.Application.Feature.Carts.Request.Command;
using Shop.Common.ResultPattern;

namespace Shop.EndPoint.Controllers.Cart
{
    public class ShoppingCartController : BaseControllers
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddToCart/{id}")]
        public IActionResult AddToCart(Guid id, AddToCartDto input)
        {

            var result = _mediator.Send(new AddToCartRequest()
            {
                add = input,
                UserId = id
            });
            return Ok(result);
        }
        [HttpPut("RemoveFromCart/{id}")]
        public IActionResult RemoveFromCart(Guid id, RemoveFromCartDto input)
        {
            var result = _mediator.Send(new RemoveFromCartRequest()
            {
                remove = input,
                UserId = id
            });
            return Ok(result);
        }
    }
}
