using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class CatalogoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        public int IdCatalogo { get; set; }
        public string SecuenciaD { get; set; }
        public string NombreD { get; set; }

        public int EstadoD { get; set; }

        public ICollection<DetalleCatalogoViewModel> DetalleCatalogos { get; set; }
    }
}
