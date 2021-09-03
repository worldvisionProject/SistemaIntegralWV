using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class EstadosSolicitud : AuditableEntity
    {
        public int Estado { get; set; }
        public int IdSolicitud { get; set; }
        //Tabla Padre
        public Solicitud Solicitudes { get; set; }
    }
}
