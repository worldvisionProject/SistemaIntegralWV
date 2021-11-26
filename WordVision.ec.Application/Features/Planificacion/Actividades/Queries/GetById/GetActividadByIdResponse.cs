using System;
using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById
{
    public class GetActividadByIdResponse
    {
        public int Id { get; set; }
        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int IdCargoResponsable { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? Ponderacion { get; set; }
        public string SNPresupuesto { get; set; }
        public decimal? TechoPresupuestoCC { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? TotalRecurso { get; set; }
        public int IdIndicadorPOA { get; set; }
        public IndicadorPOA IndicadorPOAs { get; set; }
        public ICollection<Recurso> Recursos { get; set; }
    }
}
