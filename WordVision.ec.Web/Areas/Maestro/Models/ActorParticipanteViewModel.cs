using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ActorParticipanteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        public string ActoresParticipantes { get; set; }

        public string Descripcion { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList EstadoList { get; set; }

    }
}
