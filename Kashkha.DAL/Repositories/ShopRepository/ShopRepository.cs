using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
    internal class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(KashkhaContext context) : base(context)
        {
        }
    }
}
