using WordVision.ec.Application.DTOs.Planificacion;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.IndicadorPR;
using WordVision.ec.Application.Features.Maestro.LogFrame;

namespace WordVision.ec.Application.Features.Maestro.LogFrameIndicadorPR
{
    public class LogFrameIndicadorPRResponse : GenericResponse
    {
        public int Id { get; set; }
        public int IdLogFrame { get; set; }
        public LogFrameResponse LogFrame { get; set; }

        public int IdIndicadorPR { get; set; }
        public IndicadorPRResponse IndicadorPR { get; set; }

        //public int IdEstado { get; set; }
        //public DetalleCatalogoResponse Estado { get; set; }

        //public string CodigoIndicador { get; set; }
        //public string DescripcionIndicador { get; set; }

        //public bool Selected { get; set; }

    }
}
