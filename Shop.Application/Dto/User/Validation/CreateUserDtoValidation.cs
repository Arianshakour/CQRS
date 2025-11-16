using FluentValidation;
using Shop.Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.User.Validation
{
    public class CreateUserDtoValidation : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserDtoValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.FullName).NotEmpty().WithMessage("نام نباید خالی باشد");
            //inja chek mikonim ke hamchin usernamei dar db nabashe
            RuleFor(x => x.UserName).Must(username =>
            {
                var exists = _userRepository.CheckWithUserName(username);
                return !exists;
            }).WithMessage("همچین نام کاربری موجود می باشد");

            RuleFor(x => x.Email).EmailAddress().WithMessage("ایمیلی که وارد کردید درست نیست!");
            RuleFor(x => x.password).Empty().WithMessage("نباید خالی باشد").Matches(@"[A-Z]+")
                .WithMessage("رمز عبور باید شامل حروف بزرگ انگلیسی باشد").MinimumLength(6)
                .WithMessage("طول پسورد شما کمتر از ۶ کارکتر می باشد");
        }
    }
}
