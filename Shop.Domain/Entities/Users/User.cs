using Shop.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }

        public string Salt { get; set; }

        public User()//baraye ineke ydone Guid khodesh Automat besaze
        {
            Id = Guid.NewGuid();
        }

        //Relation
        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
