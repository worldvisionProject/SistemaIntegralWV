using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached
{
    public class GetAllIndicadorPOAsCachedResponse
    {
        public int Id { get; set; }
        public string IndicadorProducto { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int TipoMeta { get; set; }
        public int IdProducto { get; set; }
        public ICollection<MetaTactica> MetaTacticas { get; set; }
        public ICollection<IndicadorVinculadoPOA> IndicadorVinculadoPOAs { get; set; }
    }
}