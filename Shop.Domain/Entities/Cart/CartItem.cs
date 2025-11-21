using Shop.Domain.Base;
using Shop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Cart
{
    public class CartItem : BaseEntity  //Jadval har radif dar sabade kharid
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }

        //Relation
        //niazi nist dar Product list bezani baraye CartItem faqat dar ShoppingCart bezan
        public Product product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
