using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces.User
{
    public interface IUserRepository : IGenericRepository<Entities.Users.User>
    {
        bool ExistUser(Guid id);
        bool CheckWithUserName(string userName);
        Entities.Users.User? GetByUserName(string userName);
        Entities.Users.User? GetById(Guid id);
    }
}
