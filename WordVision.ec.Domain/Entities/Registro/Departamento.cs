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
    public class Departamento: AuditableEntity
    {
        public int IdDireccion { get; set; }
        public Direccion Direcciones { get; set; }

        [Required]
        public string Nombre { get; set; }

       [Required]
        public string Encargado { get; set; }

        [StringLength(1)]
        [Required]
        public string Estado { get; set; }

        [ForeignKey("IdDepartamento")]
        public ICollection<Cargo> Cargos { get; set; }
    }
}
