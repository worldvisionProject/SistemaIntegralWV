using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Pregunta: AuditableEntity
    {
       
        [Required]
        public int NumPregunta { get; set; }

        [StringLength(1500)]
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string DescripcionAcepto { get; set; }
        public string DescripcionUrl1 { get; set; }
        public string Url1 { get; set; }
        public string DescripcionUrl2 { get; set; }
        public string Url2 { get; set; }

        [StringLength(1)]
        [Required]
        public string Estado { get; set; }

        public int IdDocumento { get; set; }
        public Documento Documentos { get; set; }
    }
}
