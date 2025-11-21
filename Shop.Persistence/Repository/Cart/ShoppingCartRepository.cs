using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Cart;
using Shop.Domain.Interfaces.Cart;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repository.Cart
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ShopContext _db;
        public ShoppingCartRepository(ShopContext shopContext) : base(shopContext)
        {
            _db = shopContext;
        }

        public ShoppingCart CheckCartForUser(Guid userId)
        {
            //hatman include bayad bashe ta befahme user oon product ra sefaresh dade qablan ya na
            return _db.ShoppingCarts.Include(x => x.items).ThenInclude(x => x.product).FirstOrDefault(x => x.UserId == userId);
        }
    }
}
