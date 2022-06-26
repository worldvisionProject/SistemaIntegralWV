using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class OtroIndicadorViewModel
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public string Asunciones { get; set; }

        public int IdFrecuencia { get; set; }
        public DetalleCatalogoViewModel Frecuencia { get; set; }

        public int IdTipoMedida { get; set; }
        public DetalleCatalogoViewModel TipoMedida { get; set; }

        public int IdTipoIndicador { get; set; }
        public DetalleCatalogoViewModel TipoIndicador { get; set; }

        public int IdActorParticipante { get; set; }
        public ActorParticipanteViewModel ActorParticipante { get; set; }

        public int IdArea { get; set; }
        public DetalleCatalogoViewModel Area { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public bool Selected { get; set; }

        public SelectList FrecuenciaList { get; set; }
        public SelectList TipoMedidaList { get; set; }
        public SelectList TipoIndicadorList { get; set; }
        public SelectList ActorParticipanteList { get; set; }
        public SelectList AreaList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
