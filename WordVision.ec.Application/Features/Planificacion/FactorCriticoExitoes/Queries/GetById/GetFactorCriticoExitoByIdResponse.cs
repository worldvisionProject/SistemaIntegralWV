using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById
{
    public class GetFactorCriticoExitoByIdResponse
    {
        public int Id { get; set; }
        public string FactorCritico { get; set; }

        public int IdObjetivoEstra { get; set; }
        public ICollection<IndicadorEstrategico> IndicadorEstrategicos { get; set; }
    }
}