using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ObjetivoEstrategicoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Programa { get; set; }
        public string Cwbo { get; set; }
        public string Categoria { get; set; }
        public string AreaPrioridad { get; set; }
        public string Dimension { get; set; }

        public int CargoResponsable { get; set; }

        public int IdEstrategia { get; set; }

        public SelectList DimensionList { get; set; }
        public SelectList AreaList { get; set; }
        public virtual List<FactorCriticoExito> FactorCriticoExitos { get; set; }
    }
}
