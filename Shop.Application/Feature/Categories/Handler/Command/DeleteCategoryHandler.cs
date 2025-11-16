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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, Result>
    {

        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Result> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var Entity = _categoryRepository.Get(request.Id);

            if (Entity == null)
            {
                mes = "دسته بندی مورد نظر یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }

            _categoryRepository.Delete(Entity);
            return Task.FromResult(Result.Success(mes));
        }
    }
}
