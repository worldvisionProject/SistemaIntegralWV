using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById
{
    public class GetListByIdDetalleResponse
    {
        public int IdCatalogo { get; set; }
        public string Secuencia { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

    }
}
