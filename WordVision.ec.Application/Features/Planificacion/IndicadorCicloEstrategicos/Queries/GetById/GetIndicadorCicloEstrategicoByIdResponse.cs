using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById
{
    public class GetIndicadorCicloEstrategicoByIdResponse
    {

        public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        public int IdEstrategia { get; set; }
        //public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
}
}
