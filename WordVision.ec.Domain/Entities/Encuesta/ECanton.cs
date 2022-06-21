using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("ECantones", Schema = "survey")]
    public class ECanton : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Cantón")]
        public string can_nombre { get; set; }

        public EProvincia EProvincia { get; set; }
        public ICollection<EParroquia> EParroquias { get; set; }
        public ICollection<EReporteTabulado> EReporteTabulados { get; set; }


    }
}
