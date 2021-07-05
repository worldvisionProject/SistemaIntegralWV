using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class FormularioTercero
    {
     
        [Required]
        public int Id { get; set; }
        [StringLength(1)]
        public string Tipo { get; set; }

        public virtual Tercero Terceros { get; set; }

        public virtual Formulario Formularios { get; set; }
    }
}
