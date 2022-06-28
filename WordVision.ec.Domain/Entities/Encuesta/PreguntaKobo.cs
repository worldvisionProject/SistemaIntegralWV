using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;


namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("PreguntaKobos", Schema = "survey")]
    public class PreguntaKobo : AuditableEntity
    {
        [Required]
        [Display(Name = "Código WVE")]
        public string prk_CodigoWVE { get; set; }

        [Required]
        [Display(Name = "Código Kobo")]
        public string prk_CodigoKobo { get; set; }

        [Display(Name = "Descripción")]
        public string prk_Descripcion { get; set; }

        [Required]
        [Display(Name = "Últ. Actualización")]
        public DateTime prk_Fecha { get; set; }

        public EncuestaKobo EncuestaKobo { get; set; }

        public ICollection<EncuestadoPreguntaKobo> EncuestadoPreguntaKobos { get; set; }
    }
}
