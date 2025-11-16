using AutoMapper;
using MediatR;
using Shop.Application.Dto.Product.Validator;
using Shop.Application.Feature.Products.Request.Command;
using Shop.Common.ResultPattern;
using Shop.Domain.Entities.Products;
using Shop.Domain.Interfaces.Category;
using Shop.Domain.Interfaces.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Products.Handler.Command
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Result>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            //chon ctor CreateProductDtoValidation , categoryRepository migire bayad behesh pas bedim
            var validation = new CreateProductDtoValidation(_categoryRepository);
            var CreateValidator = validation.Validate(request.Create);
            if (!CreateValidator.IsValid)
            {
                var errors = CreateValidator.Errors.Select(e => e.ErrorMessage).ToList();
                return Task.FromResult(Result.ValidationFailure(errors));
            }

            var productEntity = _mapper.Map<Product>(request.Create);
            _productRepository.Create(productEntity);

            return Task.FromResult(Result.Success());//Hatman Task bezan ke khata nade

        }
    }
}
