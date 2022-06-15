using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class EstadoPorAnioFiscalViewModel
    {
        public int Id { get; set; }

        public string AnioFiscal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int IdProceso { get; set; }
        public DetalleCatalogoViewModel Proceso { get; set; }

        public int IdEstadoAnioFiscal { get; set; }
        public DetalleCatalogoViewModel EstadoAnioFiscal { get; set; }

        public SelectList ProcesoList { get; set; }
        public SelectList EstadoAnioFiscalList { get; set; }
    }
}
