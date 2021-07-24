using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetAllCached
{
    public class GetAllProductosCachedResponse
    {
        public int Id { get; set; }
        public string DescProducto { get; set; }
        public int IdCargoResponsable { get; set; }

        public int IdIndicadorEstrategico { get; set; }
        public int IdGestion { get; set; }
         public IndicadorEstrategico IndicadorEstrategicos { get; set; }
    }
}
