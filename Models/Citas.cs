using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas.Models
{
    public class Citas
    {
        [Key]
        public int Folio { get; set; }

        public DateTime FechaDeSolicitud { get; set; }

        public int Cliente_fk { get; set; }

        public int EmpresaCliente_fk { get; set; }

        public int DepartamentoResponsable_fk { get; set; }

        public int TipoDeCita_fk { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string AsuntoDeCita { get; set; }

        public DateTime FechaParaLaCita { get; set; }

        [Column(TypeName = "nvarchar(100")]
        public int EstatusDeLaAtencion_fk { get; set; }

        public string Comentarios { get; set; }

        public int Responsable_fk { get; set; }
    }
}
