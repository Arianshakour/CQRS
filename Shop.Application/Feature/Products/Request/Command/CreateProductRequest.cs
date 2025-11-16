using MediatR;
using Shop.Application.Dto.Product;
using Shop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Products.Request.Command
{
    public class CreateProductRequest : IRequest<Result>
    {
        public CreateProductDto Create { get; set; }
    }
}
