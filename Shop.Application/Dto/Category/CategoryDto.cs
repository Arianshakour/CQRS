using Shop.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.Category
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Des { get; set; }
    }
}
