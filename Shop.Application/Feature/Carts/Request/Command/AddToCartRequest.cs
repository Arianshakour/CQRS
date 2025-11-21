using MediatR;
using Shop.Application.Dto.Cart;
using Shop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Carts.Request.Command
{
    public class AddToCartRequest : IRequest<Result>
    {
        public Guid UserId { get; set; }   // az route mikhooni
        public AddToCartDto add { get; set; }
    }
}
