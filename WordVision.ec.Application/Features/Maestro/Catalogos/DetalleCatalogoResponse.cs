using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Maestro.Catalogos
{
    public class DetalleCatalogoResponse
    {
        public int Id { get; set; }
        public int IdCatalogo { get; set; }
        public string Secuencia { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }
}
