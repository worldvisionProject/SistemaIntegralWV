using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class ResultadoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Indicador { get; set; }
        public int Tipo { get; set; }
        public int TipoObjetivo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public ObjetivoAnioFiscalViewModel ObjetivoAnioFiscales { get; set; }

    
        public List<PlanificacionResultadoViewModel> PlanificacionResultados { get; set; }
    }
}
