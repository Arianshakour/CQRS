using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.Category.Validator
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("فیلد مورد نظر نباید خالی باشد");
            RuleFor(x => x.Des).MaximumLength(200).WithMessage("طول متن شما بیش از حد مجاز می باشد");
        }
    }
}
