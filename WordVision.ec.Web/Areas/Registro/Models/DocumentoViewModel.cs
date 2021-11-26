using System;
using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class DocumentoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAcepto { get; set; }
        public string Estado { get; set; }

        public string Ventana { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public List<RespuestaViewModel> Respuestas { get; set; }

        public byte[] Image { get; set; }
        public string Colaborador { get; set; }
        public string Identificacion { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }


    }
}
