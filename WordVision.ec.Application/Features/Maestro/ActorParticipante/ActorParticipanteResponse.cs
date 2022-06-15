using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;

namespace WordVision.ec.Application.Features.Maestro.ActorParticipante
{
    public class ActorParticipanteResponse : GenericResponse
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string ActoresParticipantes { get; set; }

        public string Descripcion { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoResponse Estado { get; set; }

    }
}
