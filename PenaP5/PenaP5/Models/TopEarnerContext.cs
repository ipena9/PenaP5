using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PenaP5.Models
{
    public class TopEarnerContext : DbContext
    {
        public TopEarnerContext(DbContextOptions<TopEarnerContext>options):base(options)
        {
        }
        public DbSet<TopEarners> TopEarner { get; set; }
    }
}
