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
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, Result>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            //chon ctor UpdateProductDtoValidation , categoryRepository migire bayad behesh pas bedim
            var validation = new UpdateProductDtoValidation(_categoryRepository);
            var UpdateValidator = validation.Validate(request.Update);
            if (!UpdateValidator.IsValid)
            {
                var errors = UpdateValidator.Errors.Select(e => e.ErrorMessage).ToList();
                return Task.FromResult(Result.ValidationFailure(errors));
            }
            var productEntity = _productRepository.Get(request.Update.Id);
            if(productEntity == null)
            {
                mes = "محصول مورد نظر یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            var Updateproduct = _mapper.Map(request.Update, productEntity);
            //var Updateproduct = _mapper.Map<productEntity>(request.Update); ESHTEBAH AST CHON BAYAD ENTITY BASHE NA productEntity
            _productRepository.update(productEntity);

            return Task.FromResult(Result.Success());//Hatman Task bezan ke khata nade
        }
    }
}
