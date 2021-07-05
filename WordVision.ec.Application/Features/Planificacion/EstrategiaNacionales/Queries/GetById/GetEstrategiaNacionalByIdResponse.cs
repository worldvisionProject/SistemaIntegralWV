using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById
{
    public class GetEstrategiaNacionalByIdResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }
        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
        public int IdEmpresa { get; set; }
        public string Estado { get; set; }
        public virtual List<Gestion> Gestiones { get; set; }
        public virtual List<ObjetivoEstrategico> ObjetivoEstrategicos { get; set; }
    }
}