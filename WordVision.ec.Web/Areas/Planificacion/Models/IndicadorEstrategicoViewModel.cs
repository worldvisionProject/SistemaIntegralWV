using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorEstrategicoViewModel
    {
        public int Id { get; set; }
        public string IndicadorResultado { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int IdFactorCritico { get; set; }
        public virtual List<IndicadorAFViewModel> IndicadorAFs { get; set; }
    }
}
