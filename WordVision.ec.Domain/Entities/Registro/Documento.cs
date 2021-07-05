using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Documento: AuditableEntity
    {
       

        [StringLength(1500)]
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string DescripcionAcepto { get; set; }

        [StringLength(1)]
        [Required]
        public string Estado { get; set; }

       
        //public int IdColaborador { get; set; }
        //public Colaborador Colaboradores { get; set; }

        [ForeignKey("IdDocumento")]
        public ICollection<Pregunta> Preguntas { get; set; }

    }
}
