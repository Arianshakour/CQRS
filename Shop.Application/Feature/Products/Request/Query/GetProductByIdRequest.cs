using MediatR;
using Shop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Products.Request.Query
{
    public class GetProductByIdRequest : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
