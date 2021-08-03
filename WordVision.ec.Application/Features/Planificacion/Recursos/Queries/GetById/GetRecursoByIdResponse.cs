using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Recursos.Queries.GetById
{
   
    public class GetRecursoByIdResponse
    {
        public int CentroCosto { get; set; }
        public int CuentaCodigoCC { get; set; }
        public int CategoriaMercaderia { get; set; }
        public int Insumo { get; set; }
        public string ParaqueConsultoria { get; set; }
        public string Gtrm { get; set; }
        public string JustificacionConsultoria { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Total { get; set; }
        public string DetalleInsumo { get; set; }
        public int IdActividad { get; set; }
        public Actividad Actividades { get; set; }
        public ICollection<FechaCantidadRecurso> FechaCantidadRecursos { get; set; }
    }
}
