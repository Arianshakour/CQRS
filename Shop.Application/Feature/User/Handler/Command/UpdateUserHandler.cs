using MediatR;
using Shop.Application.Dto.User.Validation;
using Shop.Application.Feature.User.Request.Command;
using Shop.Common.PasswordHasher;
using Shop.Common.ResultPattern;
using Shop.Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.User.Handler.Command
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Result>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Result> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var validation = new UpdateUserDtoValidation(_userRepository);
            var userisvalid = validation.Validate(request.update);

            if (!userisvalid.IsValid)
            {
                var errors = userisvalid.Errors.Select(e => e.ErrorMessage).ToList();
                return Task.FromResult(Result.ValidationFailure(errors));
            }

            var user = _userRepository.GetById(request.update.Id);
            if (user == null)
            {
                mes = "کاربر یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }

            user.FullName = request.update.FullName;
            user.UserName = request.update.UserName;
            user.Email = request.update.Email;

            //age karbar pas jadid dade bood => hash kon o zakhire kon
            if (!string.IsNullOrWhiteSpace(request.update.password))
            {
                string newSalt = PasswordHashExtension.GenerateSalt();
                user.password = request.update.password.Hashpassword(newSalt);
                user.Salt = newSalt;
            }

            _userRepository.update(user);

            return Task.FromResult(Result.Success());
        }
    }
}
