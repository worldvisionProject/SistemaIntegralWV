using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class RecursoViewModel
    {
        public int Id { get; set; }
        public int CentroCosto { get; set; }
        public int CuentaCodigoCC { get; set; }
        public int CategoriaMercaderia { get; set; }
        public int Insumo { get; set; }
        public string ParaqueConsultoria { get; set; }
        public string Gtrm { get; set; }
        public string JustificacionConsultoria { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string Cantidad { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string PrecioUnitario { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string Total { get; set; }
        public string DetalleInsumo { get; set; }
        public int IdActividad { get; set; }

        public ICollection<FechaCantidadRecursoViewModel> FechaCantidadRecursos { get; set; }


       public SelectList CategoriaList { get; set; }
        public SelectList InsumoList { get; set; }
        public SelectList CentroCostosList { get; set; }
        public SelectList CuentaCCList { get; set; }

        public int? Mes { get; set; }
        public SelectList MesList { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string Valor { get; set; }
    }
}
