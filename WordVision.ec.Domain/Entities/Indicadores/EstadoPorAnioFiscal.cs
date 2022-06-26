using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class EstadoPorAnioFiscal : AuditableEntity
    {
        public string AnioFiscal { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int IdProceso { get; set; }
        [ForeignKey("IdProceso")]
        public DetalleCatalogo Proceso { get; set; }

        public int IdEstadoAnioFiscal { get; set; }
        [ForeignKey("IdEstadoAnioFiscal")]
        public DetalleCatalogo EstadoAnioFiscal { get; set; }
    }
}
