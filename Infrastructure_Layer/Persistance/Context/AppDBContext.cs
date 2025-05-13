using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Persistance.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
            
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
