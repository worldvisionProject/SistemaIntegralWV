using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById
{
    public class GetCiudadByIdResponse
    {
        public int Id { get; set; }
        public int IdProvincia { get; set; }

        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public string CodigoArea { get; set; }

        public int Estado { get; set; }

    }
}
