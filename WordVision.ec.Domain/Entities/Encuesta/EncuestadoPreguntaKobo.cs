using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;


namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EncuestadoPreguntaKobos", Schema = "survey")]
    public class EncuestadoPreguntaKobo : AuditableEntity
    {
        [Required]
        public string Valor { get; set; }

        public EncuestadoKobo EncuestadoKobo { get; set; }

        public PreguntaKobo PreguntaKobo { get; set; }

    }
}
