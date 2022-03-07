using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetAllCached
{
    public class GetAllIndicadorProductoObjetivosCachedResponse
    {

        public int Id { get; set; }
        public string Indicador { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        //public int AnioFiscal { get; set; }
        public int IdProductoObjetivo { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public int ActorParticipante { get; set; }
        public ProductoObjetivo ProductoObjetivos { get; set; }
        public ICollection<IndicadorVinculadoPO> IndicadorVinculadoPOs { get; set; }
    }
}
