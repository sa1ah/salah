using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class KashkhaContext:IdentityDbContext<User>
	{
       
      
        public KashkhaContext(DbContextOptions<KashkhaContext> options):base(options)
        {
    
        }
       
        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }


      

    }
}
