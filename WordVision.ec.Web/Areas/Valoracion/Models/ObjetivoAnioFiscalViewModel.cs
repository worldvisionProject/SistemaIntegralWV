using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class ObjetivoAnioFiscalViewModel
    {
        public int Id { get; set; }
        public int AnioFiscal { get; set; }
       public decimal Ponderacion { get; set; }
        public int IdObjetivo { get; set; }
        ////public ObjetivoViewModel Objetivos { get; set; }

       
        public List<ResultadoViewModel> Resultados { get; set; }
    }
}
