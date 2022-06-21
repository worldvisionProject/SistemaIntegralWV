using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EEvaluaciones", Schema = "survey")]
    public class EEvaluacion : AuditableEntity
    {

        [Required]
        [Display(Name = "Descripción")]
        public string eva_Nombre { get; set; }

        [Required]
        [Display(Name = "Fecha Desde")]
        public DateTime eva_Desde { get; set; }

        [Required]
        [Display(Name = "Fecha Hasta")]
        public DateTime eva_Hasta { get; set; }

        public ICollection<EReporteTabulado> EReporteTabulados { get; set; }
        public ICollection<EMeta> EMetas { get; set; }



    }
}
