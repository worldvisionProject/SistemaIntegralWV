using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById
{
    public class GetPaisByIdResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public int Estado { get; set; }

        public ICollection<Provincia> Provincias { get; set; }
    }
}
