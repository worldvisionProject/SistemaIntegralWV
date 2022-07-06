using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById
{
    public class GetProvinciaByIdResponse
    {
        public int Id { get; set; }
        public int IdPais { get; set; }

        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public int Region { get; set; }

        public int Estado { get; set; }

        public ICollection<Ciudad> Ciudades { get; set; }
    }
}
