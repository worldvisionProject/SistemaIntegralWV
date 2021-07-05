using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached
{
    public class GetAllObjetivoEstrategicoesCachedResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public string Categoria { get; set; }
        public string AreaPrioridad { get; set; }
        public string Dimension { get; set; }

        public int CargoResponsable { get; set; }

        public int IdEstrategia { get; set; }
        public virtual ICollection<FactorCriticoExito> FactorCriticoExitos { get; set; }
    }
}