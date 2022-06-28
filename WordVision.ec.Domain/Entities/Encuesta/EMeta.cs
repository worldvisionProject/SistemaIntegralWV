using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EMetas", Schema = "survey")]
    public class EMeta : AuditableEntity
    {
        [Required]
        public decimal met_valor { get; set; }

        [Required]
        public EEvaluacion EEvaluacion { get; set; }

        [Required]
        public EIndicador EIndicador { get; set; }

        [Required]
        public EPrograma EPrograma { get; set; }

    }
}
