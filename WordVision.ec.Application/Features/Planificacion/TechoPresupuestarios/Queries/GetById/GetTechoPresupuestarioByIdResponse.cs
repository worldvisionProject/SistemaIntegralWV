using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Queries.GetById
{
    public class GetTechoPresupuestarioByIdResponse
    {
        public int Id { get; set; }
        public string CodigoCC { get; set; }
        public string DescripcionCC { get; set; }
        public decimal? Techo { get; set; }
    }
}
