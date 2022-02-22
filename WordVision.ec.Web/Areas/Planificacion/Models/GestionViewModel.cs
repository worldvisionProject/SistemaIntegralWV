using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class GestionViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Anio { get; set; }
        public string Estado { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Logro { get; set; }
        public SelectList EstadoList { get; set; }
        public int IdEstrategia { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public EstrategiaNacionalViewModel EstrategiaNacionales { get; set; }
    }
}
