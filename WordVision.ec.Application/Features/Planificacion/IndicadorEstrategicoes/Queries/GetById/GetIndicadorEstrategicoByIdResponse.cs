using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById
{
    public class GetIndicadorEstrategicoByIdResponse
    {
        public int Id { get; set; }
        public string IndicadorResultado { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int IdFactorCritico { get; set; }
        public FactorCriticoExito FactorCriticoExitos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<IndicadorAF> IndicadorAFs { get; set; }
        public virtual ICollection<MetaEstrategica> MetaEstrategicas { get; set; }
    }
}