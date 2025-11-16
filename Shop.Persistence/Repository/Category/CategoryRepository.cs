using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Categories;
using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Category;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repository.Category
{
    public class CategoryRepository : GenericRepository<Domain.Entities.Categories.Category>, ICategoryRepository
    {
        private readonly ShopContext _db;
        public CategoryRepository(ShopContext shopContext) : base(shopContext)
        {
            _db = shopContext;
        }
        public bool CategoryExist(int id)
        {
            return _db.Categories.Any(x => x.Id == id);
        }

        public string GetCategoryname(int id)
        {
            var name = _db.Categories.Where(x=>x.Id == id).Select(x=>x.Name).FirstOrDefault();
            if (name == null)
                throw new NullReferenceException();
            return name;
        }
    }
}
