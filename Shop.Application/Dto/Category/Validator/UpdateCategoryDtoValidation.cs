using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.Category.Validator
{
    public class UpdateCategoryDtoValidation : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("شناسه موجود نیست!");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("نام دسته بندی نباید خالی باشد!");
            RuleFor(x => x.Des).MaximumLength(200).WithMessage("طول متن شما بیش از حد مجاز می باشد");
        }
    }
}
