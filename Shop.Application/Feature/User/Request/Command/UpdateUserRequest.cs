using MediatR;
using Shop.Application.Dto.User;
using Shop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.User.Request.Command
{
    public class UpdateUserRequest : IRequest<Result>
    {
        public UpdateUserDto update { get; set; }
    }
}
