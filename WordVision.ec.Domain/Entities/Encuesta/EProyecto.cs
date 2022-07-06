using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EProyectos", Schema = "survey")]
    public class EProyecto : AuditableEntity
    {

        [Required]
        [Display(Name = "Programa Técnico")]
        public string py_nombre { get; set; }

        public ICollection<EObjetivo> EObjetivos { get; set; }
    
    }
}
