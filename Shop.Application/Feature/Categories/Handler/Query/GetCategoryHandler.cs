using MediatR;
using Shop.Application.Dto.Category;
using Shop.Application.Feature.Categories.Request.Query;
using Shop.Common.ResultPattern;
using Shop.Domain.Interfaces.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Categories.Handler.Query
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<Result> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            if (!_categoryRepository.CategoryExist(request.Id))
            {
                mes = "دسته بندی موجود نیست!";
                return Task.FromResult(Result.Failure(mes));
            }
            var enty = _categoryRepository.Get(request.Id);
            CategoryDto categoryDto = new CategoryDto()
            {
                Name = enty.Name,
                Des = enty.Des,
                Id = enty.Id
            };

            return Task.FromResult(Result.Success(categoryDto));//Hatman Task bezan ke khata nade
        }
    }
}
