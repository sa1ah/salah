using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL.Models
{
    public class User:IdentityUser
    {
        public string? ShopName { get; set; }
        public string? Address { get; set; }
        public string? Category { get; set; }
        public string? ImgUrl { get; set; }
        public IEnumerable<Order>? Orders { get; set; } = Enumerable.Empty<Order>();
        public Shop? Shop { get; set; }
    }
}
