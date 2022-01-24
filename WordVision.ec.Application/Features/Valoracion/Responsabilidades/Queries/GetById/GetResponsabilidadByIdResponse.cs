using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetById
{
    public class GetResponsabilidadByIdResponse
    {
        public int IdEstructura { get; set; }
        public string Nombre { get; set; }
        public string Indicador { get; set; }
        public int Tipo { get; set; }
        public int IdResponsabilidad { get; set; }
        public int Padre { get; set; }
    }
}
