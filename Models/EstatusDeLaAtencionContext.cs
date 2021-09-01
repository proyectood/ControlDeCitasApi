using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas.Models
{
    public class EstatusDeLaAtencionContext : DbContext
    {
        public EstatusDeLaAtencionContext(DbContextOptions<EstatusDeLaAtencionContext> options) : base(options)
        {

        }

        public DbSet<EstatusDeLaAtencion> EstatusDeLaAtencion { get; set; }
    }
}
