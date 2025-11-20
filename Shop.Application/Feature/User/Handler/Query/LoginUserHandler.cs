using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Feature.User.Request.Query;
using Shop.Common.PasswordHasher;
using Shop.Common.ResultPattern;
using Shop.Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.User.Handler.Query
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, Result>
    {
        private readonly IUserRepository _userRepository;
        //baraye dastresi be appsettings
        private readonly IConfiguration _configuration;

        public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public Task<Result> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var user = _userRepository.GetByUserName(request.userDto.UserName);
            if (user == null)
            {
                mes = "کاربر یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            //tarkibe pass voroodi karbar ba salt zakhire shode dar database
            var userpassword = request.userDto.password.Hashpassword(user.Salt);
            if (user.password != userpassword)
            {
                mes = "رمز عبور اشتباه است";
                return Task.FromResult(Result.Failure(mes));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };
            //claim ha hamishe az Dataabase bgir
            //Sub va Jti olgo haye standard hastan mitooni esme delkhah ham bdi masalan claimsForToken.Add(new Claim("Id", user.Id.ToString()));
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var Card = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: Card
            );
            //bargardandan token sakhte shode
            return Task.FromResult(Result.Success(new JwtSecurityTokenHandler().WriteToken(token), mes));
        }
    }
}
