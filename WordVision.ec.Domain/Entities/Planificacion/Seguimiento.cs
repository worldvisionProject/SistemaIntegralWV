using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class Seguimiento : AuditableEntity
    {
        [Required]
        public int IdIndicador { get; set; }
        [Required]
        [StringLength(3)]
        public string Tipo { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public string Avance { get; set; }
        [Required]
        public decimal? PorcentajeAvance { get; set; }


        public string RutaAdjunto { get; set; }


        public string NombreAdjunto { get; set; }
        [Required]
        public string AvanceCompetencia { get; set; }
    }
}
