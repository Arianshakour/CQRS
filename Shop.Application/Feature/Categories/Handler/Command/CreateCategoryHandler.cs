using MediatR;
using Shop.Application.Dto.Category.Validator;
using Shop.Application.Feature.Categories.Request.Command;
using Shop.Common.ResultPattern;
using Shop.Domain.Entities.Categories;
using Shop.Domain.Interfaces.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Categories.Handler.Command
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<Result> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            CreateCategoryValidation validation = new CreateCategoryValidation();
            var CreateCategoryValidator = validation.Validate(request.Create);
            if (!CreateCategoryValidator.IsValid)
            {
                var errors = CreateCategoryValidator.Errors.Select(e => e.ErrorMessage).ToList();
                //return Task.FromResult(Result.Failure(mes));//Hatman Task bezan ke khata nade
                return Task.FromResult(Result.ValidationFailure(errors));
            }
            Category category = new Category()
            {
                Name = request.Create.Name,
                Des = request.Create.Des
            };
            _categoryRepository.Create(category);
            return Task.FromResult(Result.Success());//Hatman Task bezan ke khata nade
        }
    }
}
