using Shop.Domain.Base;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Cart
{
    public class ShoppingCart : BaseEntity //jadvale sabade kharid
    {
        public Guid UserId { get; set; }
        public Decimal Totalprice //in field dar database nemire chon faqat get hast
        {
            get
            {
                return items?.Sum(x => x.product.Price * x.Quantity) ?? 0;
            }
        }

        //Relation
        public List<CartItem> items { get; set; } = new List<CartItem>();
        public User User { get; set; }
    }
}
