using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class ProvinciaViewModel
    {
        public int Id { get; set; }
        public int IdPais { get; set; }

        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public int Region { get; set; }

        public int Estado { get; set; }

        public ICollection<CiudadViewModel> Ciudades { get; set; }


    }
}
