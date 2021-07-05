using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ActividadViewModel
    {
        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int IdCargoResponsable { get; set; }
        public DateTime? Plazo { get; set; }
        public decimal? TechoPresupuestoCC { get; set; }
        public decimal? Ponderacion { get; set; }
        public decimal? Saldo { get; set; }
        public int IdIndicadorPOA { get; set; }
    }
}
