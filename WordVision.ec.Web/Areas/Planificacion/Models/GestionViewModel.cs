using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class GestionViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Anio { get; set; }
        public string Estado { get; set; }
        public int IdEstrategia { get; set; }

        public EstrategiaNacionalViewModel EstrategiaNacionales { get; set; }
    }
}
