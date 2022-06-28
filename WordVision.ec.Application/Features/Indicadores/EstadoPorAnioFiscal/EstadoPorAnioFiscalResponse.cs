using System;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;

namespace WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal
{
    public class EstadoPorAnioFiscalResponse : GenericResponse
    {
        public int Id { get; set; }
        public string AnioFiscal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int IdProceso { get; set; }
        public DetalleCatalogoResponse Proceso { get; set; }

        public int IdEstadoAnioFiscal { get; set; }
        public DetalleCatalogoResponse EstadoAnioFiscal { get; set; }
       
    }
}
