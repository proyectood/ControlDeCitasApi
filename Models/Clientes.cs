using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas.Models
{
    public class Clientes
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
    }
}
