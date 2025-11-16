using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces.Category
{
    public interface ICategoryRepository : IGenericRepository<Entities.Categories.Category>
    {
        bool CategoryExist(int id);
        string GetCategoryname(int id);
    }
}
