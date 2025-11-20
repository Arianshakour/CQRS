using FluentValidation;
using Shop.Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.User.Validation
{
    public class UpdateUserDtoValidation : AbstractValidator<UpdateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserDtoValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.FullName).NotEmpty().WithMessage("نام نباید خالی باشد");
            //inja chek mikonim ke hamchin usernamei dar db nabashe

            //raft dar Handler chek beshe
            //RuleFor(x => x.UserName).Must((model, username) =>
            //{
            //    var user = _userRepository.GetByUserName(username);

            //    if (user == null)
            //        return true; // yani useri ke vared karde to db nist pas okeye

            //    return user.Id == model.Id;
            //    // age true beshe yani useri ke vared karde male khodeshe pas moshkeli nis
            //    // age false beshe yani useri ke vared karde male yki dgas pas khata bayad bede 
            //}).WithMessage("همچین نام کاربری موجود می باشد");


            //faqat vaqti password bezane chek mishe age khali bede in validation haye zir chek nemishe

            RuleFor(x => x.Email).EmailAddress().WithMessage("ایمیلی که وارد کردید درست نیست!");
            RuleFor(x => x.password).Matches(@"[A-Z]+").WithMessage("رمز عبور باید شامل حروف بزرگ انگلیسی باشد")
                .MinimumLength(6).WithMessage("طول پسورد شما کمتر از ۶ کارکتر می باشد")
                .When(x => !string.IsNullOrWhiteSpace(x.password));
        }
    }
}
