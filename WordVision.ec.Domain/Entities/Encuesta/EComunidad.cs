using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EComunidades", Schema = "survey")]
    public class EComunidad : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Comunidad")]
        public string com_nombre { get; set; }
        public EParroquia eParroquia { get; set; }

    }
}
