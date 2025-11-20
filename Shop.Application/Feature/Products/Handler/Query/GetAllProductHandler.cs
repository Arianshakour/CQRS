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
    public class GetAllProductHandler : IRequestHandler<GetAllProudctRequest, Result>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(GetAllProudctRequest request, CancellationToken cancellationToken)
        {
            var Products = _productRepository.GetAll();
            //return Task.FromResult(Result.Success(_mapper.Map<List<ProductDto>>(Products)));//Hatman Task bezan ke khata nade
            var dtoList = _mapper.Map<List<ProductDto>>(Products);
            //Andakhtan Name Category
            foreach (var item in dtoList)
            {
                item.Categoryname = _categoryRepository.GetCategoryname(item.CategoryId);
            }
            return Task.FromResult(Result.Success(dtoList));
        }
    }
}
