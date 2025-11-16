using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Dto.Product;
using Shop.Application.Feature.Products.Request.Command;
using Shop.Application.Feature.Products.Request.Query;

namespace Shop.EndPoint.Controllers.Product
{
    public class ProductsController : BaseControllers
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Product/{id}")]
        public IActionResult GetProductById(int id)
        {
            var res = _mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(res);
        }
        [HttpGet("Products")]
        public IActionResult GetAllProduct()
        {
            var res = _mediator.Send(new GetAllProudctRequest());
            return Ok(res);
        }
        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(CreateProductDto input)
        {
            var res = _mediator.Send(new CreateProductRequest() { Create = input });
            return Ok(res);
        }
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductDto input)
        {
            var res = _mediator.Send(new UpdateProductRequest() { Update = input });
            return Ok(res);
        }
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var res = _mediator.Send(new DeleteProductRequest() { Id = id });
            return Ok(res);
        }
    }
}
