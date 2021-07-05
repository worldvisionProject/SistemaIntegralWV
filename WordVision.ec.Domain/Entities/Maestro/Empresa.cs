using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class Empresa : AuditableEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Pais { get; set; }
        public string PaginaWeb { get; set; }
        public string Contacto { get; set; }
   
        [Required]
        public int Estado { get; set; }

        [ForeignKey("IdEmpresa")]
        public ICollection<Estructura> Estructuras { get; set; }
    }
}
