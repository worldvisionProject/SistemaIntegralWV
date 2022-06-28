using System;

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById
{
    public class GetGestionByIdResponse
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Anio { get; set; }

        public string Estado { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int IdEstrategia { get; set; }
    }
}