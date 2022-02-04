using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ObjetivoEstrategicoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }
        public int Categoria { get; set; }
        public int AreaPrioridad { get; set; }
        public int? Dimension { get; set; }

        public int CargoResponsable { get; set; }

        public int IdEstrategia { get; set; }

        //CAMPOS PERSONALIZADOS
        public SelectList DimensionList { get; set; }
        public SelectList AreaList { get; set; }
        public SelectList ProgramaList { get; set; }
        public SelectList CwboList { get; set; }
        public SelectList AnioFiscalList { get; set; }
        public virtual List<FactorCriticoExito> FactorCriticoExitos { get; set; }
        public ICollection<ProductoObjetivo> ProductoObjetivos { get; set; }
    }
}
