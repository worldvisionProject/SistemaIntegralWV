using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;

namespace WordVision.ec.Application.Features.Maestro.LogFrame
{
    public class LogFrameResponse : GenericResponse
    {
        public int Id { get; set; }
        public string OutCome { get; set; }

        public string OutPut { get; set; }

        public string Activity { get; set; }

        public string SumaryObjetives { get; set; }

        public int IdNivel { get; set; }
        public DetalleCatalogoResponse Nivel { get; set; }
        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }

    }
}
