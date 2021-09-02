using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Queries.GetAllCached
{
    public class GetAllProductoObjetivosCachedResponse
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int IdObjetivoEstra { get; set; }
        public ObjetivoEstrategico ObjetivoEstrategicos { get; set; }
        public ICollection<IndicadorProductoObjetivo> IndicadorProductoObjetivos { get; set; }

    }
}
