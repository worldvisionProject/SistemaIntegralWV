using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class ActividadViewModel
    {
        public int Id { get; set; }
        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int IdCargoResponsable { get; set; }
        public DateTime? Plazo { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string TechoPresupuestoCC { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string Ponderacion { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string Saldo { get; set; }
        public int IdIndicadorPOA { get; set; }
        public ICollection<RecursoViewModel> Recursos { get; set; }


        public string DescObjetivo { get; set; }
        public string DescFactor { get; set; }
        public string DescIndicador { get; set; }
        public string DescMeta { get; set; }
        public string ResponsableIndicador { get; set; }
        public string DescGestion { get; set; }
        public string DescLineaBase { get; set; }
        public string DescResponsable { get; set; }
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public string IndicadorProducto { get; set; }
        public SelectList responsableList { get; set; }

        public SelectList CategoriaList { get; set; }
        public SelectList InsumoList { get; set; }
        public SelectList CentroCostosList { get; set; }
        public SelectList CuentaCCList { get; set; }

    }
}
