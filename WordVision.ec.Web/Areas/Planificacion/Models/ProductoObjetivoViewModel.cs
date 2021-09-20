using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ProductoObjetivoViewModel
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int IdObjetivoEstra { get; set; }
        public ICollection<IndicadorProductoObjetivoViewModel> IndicadorProductoObjetivos { get; set; }

    }
}
