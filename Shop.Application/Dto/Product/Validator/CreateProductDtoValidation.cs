using FluentValidation;
using Shop.Domain.Interfaces.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.Product.Validator
{
    public class CreateProductDtoValidation : AbstractValidator<CreateProductDto>
    {
        //chon validation baraye CategoryId neveshtim bayad CategoryRepository ham inject mishod
        private ICategoryRepository _categoryRepository;
        public CreateProductDtoValidation(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage("فیلد نام را پرکنید!").MaximumLength(150)
            .WithMessage("طول عبارت بیشتر از حد مجاز است! ");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("طول عبارت بییشتر از صفر نیست!");

            //inja mirim bbinim asan oon category mojod hast ya na
            RuleFor(x => x.CategoryId).Must(x => _categoryRepository.CategoryExist(x))
                .WithMessage("دسته مورد نظر موجود نمی‌باشد!");
        }
    }
}
