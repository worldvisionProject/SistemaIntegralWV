using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Documentos.Queries.GetById
{
    public class GetDocumentoByIdResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAcepto { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<WordVision.ec.Domain.Entities.Registro.Pregunta> Preguntas { get; set; }
    }
}