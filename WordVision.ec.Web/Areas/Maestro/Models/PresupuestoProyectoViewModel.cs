using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class PresupuestoProyectoViewModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public decimal Total { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public decimal CostoSoporte { get; set; }

        public decimal Nomina { get; set; }

        public decimal TI { get; set; }

        public decimal Administracion { get; set; }

        public decimal LineamientosOnAdmistrativos { get; set; }

        public decimal LineamientosOnOperativos { get; set; }

        public decimal TechoPresupuestario { get; set; }

        public int IdProgramaArea { get; set; }
        public ProgramaAreaViewModel ProgramaArea { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public SelectList ProgramaAreaList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
