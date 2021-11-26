using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Direccion : AuditableEntity
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Encargado { get; set; }

        [StringLength(1)]
        [Required]
        public string Estado { get; set; }

        [ForeignKey("IdDireccion")]
        public ICollection<Departamento> Departamentos { get; set; }

    }
}
