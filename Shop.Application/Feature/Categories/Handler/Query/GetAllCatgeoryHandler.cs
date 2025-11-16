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
    public class GetAllCatgeoryHandler : IRequestHandler<GetAllCatgeoryRequest, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCatgeoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<Result> Handle(GetAllCatgeoryRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var Categoreis = _categoryRepository.GetAll();
            var categoriesDto = Categoreis.Select(x => new CategoryDto()
            {
                Name = x.Name,
                Des = x.Des,
                Id = x.Id
            });

            return Task.FromResult(Result.Success(categoriesDto, mes));//Hatman Task bezan ke khata nade
        }
    }
}
