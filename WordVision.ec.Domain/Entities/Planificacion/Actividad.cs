using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class Actividad : AuditableEntity
    {
        public string DescripcionActividad { get; set; }
        [Required]
        public string Entregable { get; set; }
        [Required]
        public int IdCargoResponsable { get; set; }
        [Required]
        public DateTime Plazo { get; set; }
        [Required]
        public decimal? TechoPresupuestoCC { get; set; }
        [Required]
        public decimal? Ponderacion { get; set; }
       
        public decimal? Saldo { get; set; }

        public int IdIndicadorPOA { get; set; }
        public IndicadorPOA IndicadorPOAs { get; set; }
    }
}
