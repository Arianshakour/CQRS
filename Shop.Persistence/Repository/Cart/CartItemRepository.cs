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
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly ShopContext _db;
        public CartItemRepository(ShopContext shopContext) : base(shopContext)
        {
            _db = shopContext;
        }
    }
}
