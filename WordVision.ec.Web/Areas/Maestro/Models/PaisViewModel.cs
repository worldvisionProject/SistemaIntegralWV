using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class PaisViewModel
    {
        public int Id { get; set; }
      public string Nombre { get; set; }

        public string Codigo { get; set; }

        public int Estado { get; set; }
        public ICollection<ProvinciaViewModel> Provincias { get; set; }
    }
}
