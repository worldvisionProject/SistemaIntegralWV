using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Registro.Idiomas.Queries.GetById
{
    public class GetByIdResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Hablado { get; set; }
        public decimal Escrito { get; set; }
        public int IdFormulario { get; set; }
    }
}
