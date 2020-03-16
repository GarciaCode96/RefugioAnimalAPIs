using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIFake.Data
{
    public class RefugioDbContext : DbContext
    {
        public RefugioDbContext(DbContextOptions<RefugioDbContext> optionsContext) 
            : base(optionsContext){}

        public DbSet<AnimalEntity> Animal { get; set; }
    }
}
