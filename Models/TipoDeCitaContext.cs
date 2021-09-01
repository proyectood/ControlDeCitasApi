using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas.Models
{
    public class TipoDeCitaContext : DbContext
    {
        public TipoDeCitaContext(DbContextOptions<TipoDeCitaContext> options) : base(options)
        {

        }

        public DbSet<TipoDeCita> TipoDeCita { get; set; }
    }
}
