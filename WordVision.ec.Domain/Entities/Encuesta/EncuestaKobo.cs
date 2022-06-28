using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EncuestaKobos", Schema = "survey")]
    public class EncuestaKobo : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "String ID")]
        public string enk_Id_string { get; set; }

        [Required]
        [Display(Name = "Nombre Encuesta")]
        public string enk_Title { get; set; }

        [Display(Name = "Descripción")]
        public string enk_Description { get; set; }

        [Required]
        [Display(Name = "URL")]
        public string enk_Url { get; set; }

        
        [Display(Name = "Últ. Actualización")]
        public DateTime? enk_Fecha { get; set; }

        public ICollection<PreguntaKobo> PreguntaKobos { get; set; }

        public ICollection<EncuestadoKobo> EncuestadoKobos { get; set; }

    }
}
