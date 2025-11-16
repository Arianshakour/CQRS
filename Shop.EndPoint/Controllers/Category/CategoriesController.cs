using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Dto.Category;
using Shop.Application.Feature.Categories.Request.Command;
using Shop.Application.Feature.Categories.Request.Query;

namespace Shop.EndPoint.Controllers.Category
{
    public class CategoriesController : BaseControllers
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Categories")]
        public IActionResult GetAllCategory()
        {
            var result = _mediator.Send(new GetAllCatgeoryRequest());
            return Ok(result);
        }
        [HttpGet("Category/{id}")]
        public IActionResult GetCategory(int id)
        {
            var result = _mediator.Send(new GetCategoryRequest() { Id = id});
            return Ok(result);
        }
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDto input)
        {
            var result = _mediator.Send(new CreateCategoryRequest() { Create = input});
            return Ok(result);
        }
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(UpdateCategoryDto input)
        {
            var result = _mediator.Send(new UpdateCategoryRequest() { Update = input });
            return Ok(result);
        }
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _mediator.Send(new DeleteCategoryRequest() { Id = id});
            return Ok(result);
        }
    }
}
