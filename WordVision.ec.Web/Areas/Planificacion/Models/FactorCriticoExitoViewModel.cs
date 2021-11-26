using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class FactorCriticoExitoViewModel
    {
        public int Id { get; set; }
        public string FactorCritico { get; set; }
        public int IdObjetivoEstra { get; set; }
        public int IdEstrategia { get; set; }
        public int IdGestion { get; set; }
        public virtual List<IndicadorEstrategicoViewModel> IndicadorEstrategicos { get; set; }

        public virtual ObjetivoEstrategicoViewModel ObjetivoEstrategicos { get; set; }

        public SelectList responsableList { get; set; }

    }
}
