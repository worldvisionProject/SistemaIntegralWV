using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class EstadosSolicitud : AuditableEntity
    {
        [Required]
        public int Estado { get; set; }
        public int IdSolicitud { get; set; }
        //Tabla Padre
        public Solicitud Solicitudes { get; set; }
    }
}
