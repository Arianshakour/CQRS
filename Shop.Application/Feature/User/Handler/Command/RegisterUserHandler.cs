using AutoMapper;
using MediatR;
using Shop.Application.Dto.User.Validation;
using Shop.Application.Feature.User.Request.Command;
using Shop.Common.PasswordHasher;
using Shop.Common.ResultPattern;
using Shop.Domain.Entities.Users;
using Shop.Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.User.Handler.Command
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public Task<Result> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var validation = new CreateUserDtoValidation(_userRepository);
            var userisvalid = validation.Validate(request.create);

            if (!userisvalid.IsValid)
            {
                var errors = userisvalid.Errors.Select(e => e.ErrorMessage).ToList();
                return Task.FromResult(Result.ValidationFailure(errors));
            }

            var userEntity = _mapper.Map<Domain.Entities.Users.User>(request.create);

            var salt = PasswordHashExtension.GenerateSalt();

            userEntity.password = userEntity.password.Hashpassword(salt);
            //chon this gozashti shode extention method yani vorodie avalesh userEntity.password mishe
            //injoori ham mishe benevisi vali khanaeie kamtari dare => PasswordHashExtension.Hashpassword(userEntity.password, salt);
            //albate dar asl dare hamin khate balaro ejra mikone
            // masalan "hello".ToUpper();
            // dar asl in boode => stringExtensions.ToUpper("hello");
            // bekhatere oon this hast
            userEntity.Salt = salt;//salt bayad zakhire koni ta moqe login karbar ham bayad az hamin estefade koni
            _userRepository.Create(userEntity);
            return Task.FromResult(Result.Success());//Hatman Task bezan ke khata nade
        }
    }
}
