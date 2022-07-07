using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EObjetivos", Schema = "survey")]
    public class EObjetivo : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string obj_Nombre { get; set; }

        public string obj_Nivel { get; set; }
        public string obj_Outcome { get; set; }
        public string obj_Output { get; set; }
        public string obj_Activity { get; set; }


        public EProyecto EProyecto { get; set; }

        public ICollection<EIndicador> EIndicadores { get; set; }




    }
}
