using MediatR;
using Shop.Application.Dto.Base;
using Shop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Products.Request.Query
{
    public class GetAllProudctRequest : IRequest<Result>
    {
        public FilteringDto filter { get; set; }
    }
}
