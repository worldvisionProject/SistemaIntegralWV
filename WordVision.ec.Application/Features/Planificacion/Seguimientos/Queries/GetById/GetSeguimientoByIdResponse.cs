using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Seguimientos.Queries.GetById
{
    public class GetSeguimientoByIdResponse
    {
        public int Id { get; set; }
        public int IdIndicador { get; set; }
        public string Tipo { get; set; }
        public int Mes { get; set; }
        public string Avance { get; set; }
        public decimal? PorcentajeAvance { get; set; }
        public string RutaAdjunto { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string NombreAdjunto { get; set; }
        public string AvanceCompetencia { get; set; }
    }
}
