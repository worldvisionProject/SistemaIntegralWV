using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string DescCargoResponsable { get; set; }
        public int IdGestion { get; set; }
        public IndicadorEstrategicoViewModel IndicadorEstrategicos { get; set; }
        public ICollection<IndicadorPOAViewModel> IndicadorPOAs { get; set; }
    }
}
