using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.ActorParticipante;
using WordVision.ec.Application.Features.Maestro.Catalogos;

namespace WordVision.ec.Application.Features.Maestro.OtroIndicador
{
    public class OtroIndicadorResponse : GenericResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string Descripcion    { get; set; }

        public string Asunciones { get; set; }

        public int IdFrecuencia { get; set; }
        public DetalleCatalogoResponse Frecuencia { get; set; }

        public int IdTipoMedida { get; set; }
        public DetalleCatalogoResponse TipoMedida { get; set; }

        public int IdTipoIndicador { get; set; }
        public DetalleCatalogoResponse TipoIndicador { get; set; }

        public int IdActorParticipante { get; set; }
        public ActorParticipanteResponse ActorParticipante { get; set; }

        public int IdArea { get; set; }
        public DetalleCatalogoResponse Area { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }
    }
}
