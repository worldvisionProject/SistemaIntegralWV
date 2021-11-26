using System;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class Email : AuditableEntity
    {
        public int IdSolicitud { get; set; }
        public int Estado { get; set; }
        public DateTime FechaEnvioEmail { get; set; }

        public string PersonaEnvioEmail { get; set; }
    }
}
