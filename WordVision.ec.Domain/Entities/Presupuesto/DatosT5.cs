using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Presupuesto
{
    public class DatosT5 : AuditableEntity
    {
      
        [StringLength(150)]
        [Required]
        public string Codigo { get; set; }

        [StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(150)]
        public string Cuentasop { get; set; }

        [StringLength(150)]
        public string T2 { get; set; }

        [StringLength(150)]
        public string DescripcionT2 { get; set; }

    
        public int Tipo { get; set; }
        

    }
}
