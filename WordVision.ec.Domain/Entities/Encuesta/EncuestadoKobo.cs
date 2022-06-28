using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EncuestadoKobos", Schema = "survey")]
    public class EncuestadoKobo : AuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string eko_xform_id_string { get; set; }

        [Required]
        public string eko_formhub { get; set; }

        [Required]
        public DateTime eko_start { get; set; }

        [Required]
        public DateTime eko_end { get; set; }

        [Required]
        public DateTime eko_today { get; set; }

        [Required]
        public string eko_deviceid { get; set; }

        [Required]
        public string eko_imei { get; set; }

        [Required]
        public string eko_username { get; set; }

        public string eko_secuencial { get; set; }

        [Required]
        public string eko_pa { get; set; }

        [Required]
        public string eko_region { get; set; }

        [Required]
        public string eko_provincia { get; set; }

        [Required]
        public string eko_canton { get; set; }

        [Required]
        public string eko_parroquia { get; set; }

        [Required]
        public string eko_comunidad { get; set; }

        public string eko_desastre { get; set; }

        [Required]
        public string eko_nombre_encuestador { get; set; }

        [Required]
        public DateTime eko_fecha { get; set; }

        public string eko_ref_vivienda { get; set; }

        [Required]
        public string eko_nombre_nino { get; set; }

        [Required]
        public string eko_sexo { get; set; }

        [Required]
        public string eko_patrocinio { get; set; }

        [Required]
        public string eko_status { get; set; }

        public EncuestaKobo EncuestaKobo { get; set; }

        public ICollection<EncuestadoPreguntaKobo> EncuestadoPreguntaKobos { get; set; }

    }
}
