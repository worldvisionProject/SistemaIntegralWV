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
    public class Idioma : AuditableEntity
    {
        [StringLength(50)]
        public string Nombre { get; set; }

       
        public decimal Hablado { get; set; }

     
        public decimal Escrito { get; set; }

       public int IdFormulario { get; set; }
        public Formulario Formularios { get; set; }
    }
}
