using Shop.Domain.Base;
using Shop.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }//ForeignKey
        public Category Category { get; set; }//Relation one to many
    }
}
