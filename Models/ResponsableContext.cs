using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas.Models
{
    public class ResponsableContext : DbContext
    {
        public ResponsableContext(DbContextOptions<ResponsableContext> options) : base(options)
        {

        }

        public DbSet<Responsable> Responsable { get; set; }
    }
}
