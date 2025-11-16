using Shop.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Des { get; set; }
    }
}
