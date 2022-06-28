using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById
{
    public class GetResultadoByIdResponse
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EsObligatorio { get; set; }
        public string Indicador { get; set; }
        public int Tipo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
    }
}
