using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EIndicadorUsuarios", Schema = "survey")]
    public class EIndicadorUsuario : AuditableEntity
    {
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [Required]
        public EIndicador EIndicador { get; set; }

    }
}
