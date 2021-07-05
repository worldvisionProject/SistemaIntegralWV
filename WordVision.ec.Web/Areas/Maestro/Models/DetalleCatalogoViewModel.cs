using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class DetalleCatalogoViewModel
    {
        public int Id { get; set; }
        public int IdCatalogo { get; set; }
        public string Secuencia { get; set; }
        public string Nombre { get; set; }

        public int Estado { get; set; }
    }
}
