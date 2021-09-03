using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetAllCached
{
    public class GetAllIndicadorProductoObjetivosCachedResponse
    {
      
    public int Id { get; set; }
    public string Indicador { get; set; }

    public int AnioFiscal { get; set; }
    public int IdProductoObjetivo { get; set; }
    public ProductoObjetivo ProductoObjetivos { get; set; }
}
}
