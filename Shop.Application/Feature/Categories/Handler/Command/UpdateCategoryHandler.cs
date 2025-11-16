using MediatR;
using Shop.Application.Dto.Category.Validator;
using Shop.Application.Feature.Categories.Request.Command;
using Shop.Common.ResultPattern;
using Shop.Domain.Interfaces.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Categories.Handler.Command
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<Result> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            UpdateCategoryDtoValidation validation = new UpdateCategoryDtoValidation();
            var CategoryisVaild = validation.Validate(request.Update);
            if (!CategoryisVaild.IsValid)
            {
                var errors = CategoryisVaild.Errors.Select(e => e.ErrorMessage).ToList();
                return Task.FromResult(Result.ValidationFailure(errors));//Hatman Task bezan ke khata nade
            }
            var enty = _categoryRepository.Get(request.Update.Id);
            if (enty == null)
            {
                mes = "دسته بندی مورد نظر یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            enty.Name = request.Update.Name;
            enty.Des = request.Update.Des;

            _categoryRepository.update(enty);

            return Task.FromResult(Result.Success(mes));
        }
    }
}
