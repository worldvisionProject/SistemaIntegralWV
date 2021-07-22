using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById
{
    public class GetIndicadorPOAByIdResponse
    {
        public int Id { get; set; }
        public string IndicadorProducto { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int IdProducto { get; set; }
        public Producto Productos { get; set; }
        public ICollection<Actividad> Actividades { get; set; }
        public ICollection<MetaTactica> MetaTacticas { get; set; }
    }
}