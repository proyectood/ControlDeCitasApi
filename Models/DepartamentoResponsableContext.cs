using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas.Models
{
    public class DepartamentoResponsableContext : DbContext
    {
        public DepartamentoResponsableContext(DbContextOptions<DepartamentoResponsableContext> options) : base(options)
        {

        }

        public DbSet<DepartamentoResponsable> DepartamentoResponsable { get; set; }
    }
}
