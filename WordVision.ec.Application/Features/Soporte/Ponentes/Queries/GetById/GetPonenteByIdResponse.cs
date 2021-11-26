using System;
using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById
{
    public class GetPonenteByIdResponse
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int TipoSistema { get; set; }
        public int IdAsignadoA { get; set; }
        public string AsignadoA { get; set; }
        public int Estado { get; set; }
        public string DescripcionSolucion { get; set; }
        public string ObservacionesSolucion { get; set; }
        public string ComentarioSatisfaccion { get; set; }
        public int EstadoSatisfaccion { get; set; }
        public ICollection<EstadosSolicitud> EstadosSolicitudes { get; set; }

        public Mensajeria Mensajerias { get; set; }

        public Comunicacion Comunicaciones { get; set; }
        public int IdColaborador { get; set; }
        public virtual Colaborador Colaboradores { get; set; }
    }
}
