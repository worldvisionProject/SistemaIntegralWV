using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EProgramaIndicadores", Schema = "survey")]
    public class EProgramaIndicador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int pi_Poblacion { get; set; }


        public EPrograma EPrograma { get; set; }

        public EIndicador EIndicador { get; set; }


    }
}
