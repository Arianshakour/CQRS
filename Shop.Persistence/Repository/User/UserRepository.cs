using Shop.Domain.Interfaces.User;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repository.User
{
    public class UserRepository : GenericRepository<Domain.Entities.Users.User>, IUserRepository
    {
        private readonly ShopContext _db;
        public UserRepository(ShopContext shopContext) : base(shopContext)
        {
            _db = shopContext;
        }

        public bool CheckWithUserName(string userName)
        {
            return _db.User.Any(x => x.UserName == userName);
        }

        public bool ExistUser(Guid id)
        {
            return _db.User.Any(x => x.Id == id);
        }

        public Domain.Entities.Users.User? GetById(Guid id)
        {
            return _db.User.FirstOrDefault(x => x.Id == id);
        }

        public Domain.Entities.Users.User? GetByUserName(string userName)
        {
            return _db.User.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
