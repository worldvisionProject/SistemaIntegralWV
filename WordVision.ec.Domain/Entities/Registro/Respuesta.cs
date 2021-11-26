using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Respuesta : AuditableEntity
    {
        public int IdColaborador { get; set; }
        public Colaborador Colaboradores { get; set; }
        [Required]
        public int IdDocumento { get; set; }
        [Required]
        public int IdPregunta { get; set; }
        [Required]
        public string DescRespuesta { get; set; }


    }
}
