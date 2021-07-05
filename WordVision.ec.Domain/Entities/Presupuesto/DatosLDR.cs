using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
namespace WordVision.ec.Domain.Entities.Presupuesto
{
    public class DatosLDR : AuditableEntity
    {
        [StringLength(13)]
        [Required]
        public string Identificacion { get; set; }

        [StringLength(550)]
        public string Nombres { get; set; }

        [StringLength(550)]
        public string Area { get; set; }

        [StringLength(550)]
        public string Cargo { get; set; }

        [StringLength(150)]
        [Required]
        public string Ubicacion { get; set; }

        [StringLength(150)]
        public string T0 { get; set; }

        [StringLength(150)]
        public string T1 { get; set; }

        [StringLength(150)]
        public string T2 { get; set; }

        [StringLength(150)]
        public string T3 { get; set; }

        [StringLength(150)]
        public string T4 { get; set; }
        [StringLength(150)]
        public string T5 { get; set; }

        [StringLength(150)]
        public string T6 { get; set; }

        [StringLength(150)]
        public string T7 { get; set; }

        [StringLength(150)]
        public string T8 { get; set; }

        [StringLength(150)]
        public string T9 { get; set; }

        [StringLength(1)]
        public string FijoEventual { get; set; }
        public decimal Ldr { get; set; }

        public decimal TotalGasto { get; set; }
        public decimal PorceImputado { get; set; }
        public decimal ValorImputado { get; set; }

        public int MesIngreso { get; set; }
        public int AnioIngreso { get; set; }
    }
}
