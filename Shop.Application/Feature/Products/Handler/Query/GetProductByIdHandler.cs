using AutoMapper;
using MediatR;
using Shop.Application.Dto.Product;
using Shop.Application.Feature.Products.Request.Query;
using Shop.Common.ResultPattern;
using Shop.Domain.Entities.Products;
using Shop.Domain.Interfaces.Category;
using Shop.Domain.Interfaces.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Products.Handler.Query
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, Result>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            if (!_productRepository.ProductExist(request.Id))
            {
                mes = "محصول موجود نیست!";
                return Task.FromResult(Result.Failure(mes));
            }
            var porduct = _productRepository.Get(request.Id);
            var dto = _mapper.Map<ProductDto>(porduct);
            dto.Categoryname = _categoryRepository.GetCategoryname(porduct.CategoryId);
            return Task.FromResult(Result.Success(dto));//Hatman Task bezan ke khata nade

        }
    }
}
