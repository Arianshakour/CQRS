using MediatR;
using Shop.Application.Dto.Category;
using Shop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Categories.Request.Query
{
    public class GetCategoryRequest : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
