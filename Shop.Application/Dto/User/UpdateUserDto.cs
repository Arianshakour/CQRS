using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.User
{
    public class UpdateUserDto
    {
        //public Guid Id { get; set; }
        //Id jash dar Dto nis dar route controller hast
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
