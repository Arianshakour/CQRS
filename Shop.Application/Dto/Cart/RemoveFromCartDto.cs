using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Dto.Cart
{
    public class RemoveFromCartDto
    {
        //public Guid UserId { get; set; } bayad dar route Controller bashe
        public int ProductId { get; set; }
    }
}
