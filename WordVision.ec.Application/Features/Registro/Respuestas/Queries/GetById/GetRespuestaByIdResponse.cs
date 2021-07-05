using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Registro.Respuestas.Queries.GetById
{
    public class GetRespuestaByIdResponse
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdDocumento { get; set; }
        public int IdPregunta { get; set; }
        public string DescRespuesta { get; set; }
    }
}
