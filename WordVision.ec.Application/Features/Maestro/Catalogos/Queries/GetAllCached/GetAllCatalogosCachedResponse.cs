using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetAllCached
{
    public class GetAllCatalogosCachedResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
     //   public ICollection<DetalleCatalogo> DetalleCatalogos { get; set; }
    }
}
