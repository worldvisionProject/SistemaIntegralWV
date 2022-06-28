using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EReporteTabulados", Schema = "survey")]
    public class EReporteTabulado : AuditableEntity
    {

        [Required]
        [Display(Name = "Indicador")]
        public string rta_nombre_indicador { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string rta_tipo_indicador { get; set; }

        [Required]
        [Display(Name = "Proyecto")]
        public string rta_proyecto { get; set; }

        [Required]
        [Display(Name = "Programa de Área")]
        public string rta_nombre_pa { get; set; }

        [Required]
        [Display(Name = "Numerador")]
        public decimal rta_numerador { get; set; }

        [Required]
        [Display(Name = "Denominador")]
        public decimal rta_denominador { get; set; }

        [Required]
        [Display(Name = "Porcentaje")]
        public decimal rta_porcentaje { get; set; }

        [Required]
        [Display(Name = "Resultado")]
        public decimal rta_resultado { get; set; }

        [Required]
        public EEvaluacion EEvaluacion { get; set; }
        [Required]
        public EPrograma EPrograma { get; set; }
        [Required]
        public EIndicador EIndicador { get; set; }
        [Required]
        public ERegion ERegion { get; set; }
        [Required]
        public EProvincia EProvincia { get; set; }
        [Required]
        public ECanton ECanton { get; set; }
        

    }
}
