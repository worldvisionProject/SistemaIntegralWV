using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EIndicadores", Schema = "survey")]
    public class EIndicador : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string ind_LogFrame { get; set; }

        [Required]
        public string ind_Nombre { get; set; }

        public string ind_Resultado { get; set; }

        public string ind_Definicion { get; set; }

        [Required]
        public string ind_Fuente { get; set; }

        [Required]
        public string ind_Seccion { get; set; }

        [Required]
        public string ind_Preguntas { get; set; }

        public string ind_Medicion { get; set; }

        [Required]
        public string int_PlanTabulados { get; set; }

        public string ind_UnidadMedida { get; set; }

        public int ind_Frecuencia { get; set; }

        [Required]
        public string ind_tipo { get; set; }

        [Required]
        public string ind_proyecto { get; set; }


        public EObjetivo EObjetivo { get; set; }
        public ICollection<EProgramaIndicador> EProgramaIndicadores { get; set; }
        public ICollection<EReporteTabulado> EReporteTabulados { get; set; }
        public ICollection<EMeta> EMetas { get; set; }

        

    }
}
