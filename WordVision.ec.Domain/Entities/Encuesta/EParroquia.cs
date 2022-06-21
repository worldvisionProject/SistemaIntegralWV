using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EParroquias", Schema = "survey")]
    public class EParroquia : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Parroquia")]
        public string par_nombre { get; set; }

        public EPrograma EPrograma { get; set; }

        public ECanton ECanton { get; set; }

        public ICollection<EComunidad> EComunidades { get; set; }

    }
}
