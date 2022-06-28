using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EProvincias", Schema = "survey")]
    public class EProvincia : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Provincia")]
        public string pro_nombre { get; set; }

        public ERegion eRegion { get; set; } 
        public ICollection<ECanton> ECantones { get; set; }
        public ICollection<EReporteTabulado> EReporteTabulados { get; set; }

    }
}
