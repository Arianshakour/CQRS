using Shop.Domain.Interfaces.Category;
using Shop.Domain.Interfaces.Product;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repository.Product
{
    public class ProductRepository : GenericRepository<Domain.Entities.Products.Product>, IProductRepository
    {
        private readonly ShopContext _db;
        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _db = shopContext;
        }

        public bool ProductExist(int id)
        {
            return _db.Products.Any(x => x.Id == id);
        }
    }
}
