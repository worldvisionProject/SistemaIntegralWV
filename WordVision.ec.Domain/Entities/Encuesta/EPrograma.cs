using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EProgramas", Schema = "survey")]
    public class EPrograma : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "PA")]
        public string pa_nombre { get; set; }


        public ICollection<EParroquia> EParroquias { get; set; }
        public ICollection<EProgramaIndicador> EProgramaIndicadores { get; set; }
        public ICollection<EReporteTabulado> EReporteTabulados { get; set; }
        public ICollection<EMeta> EMetas { get; set; }

    }
}
