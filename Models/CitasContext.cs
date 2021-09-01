using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas.Models
{
    public class CitasContext : DbContext
    {
        public CitasContext(DbContextOptions<CitasContext> options) : base(options)
        {

        }

        public DbSet<Citas> Citas { get; set; }
    }
}
