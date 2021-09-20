using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById
{
    public class GetObjetivoEstrategicoByIdResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public string Categoria { get; set; }
        public string AreaPrioridad { get; set; }
        public string Dimension { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }
        public int CargoResponsable { get; set; }

        public int IdEstrategia { get; set; }
        public string DescCategoria { get; set; }
        public string DescAreaPrioridad { get; set; }
        public string DescDimension { get; set; }
        public virtual ICollection<FactorCriticoExito> FactorCriticoExitos { get; set; }
        public virtual ICollection<ProductoObjetivo> ProductoObjetivos { get; set; }

    }
}