using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class ObjetivoAnioFiscalViewModel
    {
        public int Id { get; set; }
        public int AnioFiscal { get; set; }
       public decimal Ponderacion { get; set; }
        public int IdObjetivo { get; set; }

        public int Minimo { get; set; }
        public int Maximo { get; set; }
        ////public ObjetivoViewModel Objetivos { get; set; }

        public ICollection<PlanificacionResultadoViewModel> PlanificacionResultados { get; set; }
        public List<ResultadoViewModel> Resultados { get; set; }
    }
}
