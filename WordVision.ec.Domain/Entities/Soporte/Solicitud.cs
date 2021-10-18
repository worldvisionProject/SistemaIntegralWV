using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class Solicitud : AuditableEntity
    {
        // public string TipoSistema { get; set; }

        public int IdAsignadoA { get; set; }
        public string AsignadoA { get; set; }
        public int Estado { get; set; }
        public string DescripcionSolucion { get; set; }
        public string ObservacionesSolucion { get; set; }
        public int EstadoSatisfaccion { get; set; }
       
        [ForeignKey("IdSolicitud")]
        public ICollection<EstadosSolicitud> EstadosSolicitudes { get; set; }

        [ForeignKey("IdSolicitud")]
        public Mensajeria Mensajerias { get; set; }

        [ForeignKey("IdSolicitud")]
        public Comunicacion Comunicaciones { get; set; }

        public int IdColaborador { get; set; }
        public virtual Colaborador Colaboradores { get; set; }
       
    }
}
