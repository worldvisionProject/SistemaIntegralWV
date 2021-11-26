using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public int IdObjetivoEstra { get; set; }
        public int IdIndicadorEstrategico { get; set; }
        public string DescObjetivoEstra { get; set; }
        public string DescIndicadorEstrategico { get; set; }
        public string IdCategoria { get; set; }
        public string DescProducto { get; set; }

        public int IdCargoResponsable { get; set; }
        public SelectList responsableList { get; set; }
        public string DescCargoResponsable { get; set; }
        public int IdGestion { get; set; }
        public string DescGestion { get; set; }
        public string DescFactorCritico { get; set; }
        public string DescMetaGestion { get; set; }
        public IndicadorEstrategicoViewModel IndicadorEstrategicos { get; set; }
        public List<IndicadorPOAViewModel> IndicadorPOAs { get; set; }
    }
}
