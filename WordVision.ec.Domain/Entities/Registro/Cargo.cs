using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Cargo : AuditableEntity
    {
        public int IdDepartamento { get; set; }
        public Departamento Departamentos { get; set; }

        [Required]
        public string Nombre { get; set; }

        [StringLength(1)]
        [Required]
        public string Estado { get; set; }
    }
}
