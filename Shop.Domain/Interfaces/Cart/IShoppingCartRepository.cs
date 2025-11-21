using Shop.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces.Cart
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        ShoppingCart CheckCartForUser(Guid userId);
    }
}
