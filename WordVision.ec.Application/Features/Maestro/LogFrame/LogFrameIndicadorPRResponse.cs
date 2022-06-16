using System.Collections.Generic;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.ProyectoTecnico;

namespace WordVision.ec.Application.Features.Maestro.LogFrame
{
    public class LogFrameIndicadorPRResponse : GenericResponse
    {
        public int Id { get; set; }

        public int IdLogFrame { get; set; }
        public LogFrameResponse LogFrame { get; set; }

        public int IdIndicadorPR { get; set; }
        public IndicadorPRResponse IndicadorPR { get; set; }

        public string CodigoIndicador { get; set; }
        public string DescripcionIndicador { get; set; }

        public bool Selected { get; set; }

    }
}
