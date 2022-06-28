using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;


namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("ERegiones", Schema = "survey")]
    public class ERegion : AuditableEntity
    {
        [Required]
        [Display(Name = "Región")]
        public string reg_nombre { get; set; }

        public ICollection<EProvincia> EProvincias { get; set; }
        public ICollection<EReporteTabulado> EReporteTabulados { get; set; }

    }
}
