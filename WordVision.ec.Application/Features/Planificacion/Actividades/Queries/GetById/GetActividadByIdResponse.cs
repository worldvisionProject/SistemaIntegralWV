using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById
{
    public class GetActividadByIdResponse
    {
        public int Id { get; set; }
        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int IdCargoResponsable { get; set; }
        public DateTime Plazo { get; set; }
        public decimal? Ponderacion { get; set; }
        public string SNPresupuesto { get; set; }
        public decimal? TechoPresupuestoCC { get; set; }
        public decimal? Saldo { get; set; }

        public int IdIndicadorPOA { get; set; }
        public IndicadorPOA IndicadorPOAs { get; set; }
        public ICollection<Recurso> Recursos { get; set; }
    }
}
