using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.Cart.Validator
{
    public class AddTocartDtoValidator : AbstractValidator<AddToCartDto>
    {
        public AddTocartDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("محصول را وارد کنید");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("تعداد باید بزرگتر از صفر باشد");
            RuleFor(x => x.Quantity).InclusiveBetween(1, 100).WithMessage("تعداد باید بین 1 تا 100 باشد");
        }
    }
}
