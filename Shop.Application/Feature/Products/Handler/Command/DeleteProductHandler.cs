using MediatR;
using Shop.Application.Feature.Products.Request.Command;
using Shop.Common.ResultPattern;
using Shop.Domain.Interfaces.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Products.Handler.Command
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, Result>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Result> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var productEntity = _productRepository.Get(request.Id);
            if (productEntity == null)
            {
                mes = "محصول مورد نظر یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            _productRepository.Delete(productEntity);

            return Task.FromResult(Result.Success());//Hatman Task bezan ke khata nade
        }
    }
}
