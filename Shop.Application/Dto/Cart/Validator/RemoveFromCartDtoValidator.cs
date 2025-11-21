using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.Cart.Validator
{
    public class RemoveFromCartDtoValidator : AbstractValidator<RemoveFromCartDto>
    {
        public RemoveFromCartDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("محصول را وارد کنید");
        }
    }
}
