using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class PlanificacionResultadoViewModel
    {
        //public int IdObjetivo { get; set; }
        //public string NombreObjetivo { get; set; }
        //public string Numero { get; set; }
        //public string Descripcion { get; set; }
        //public int Estado { get; set; }
        //public List<ObjetivoAnioFiscalViewModel> AnioFiscales { get; set; }

        //    public int IdObjetivo { get; set; }
        //    public string NombreObjetivo { get; set; }
        //    public string Numero { get; set; }
        //    public string Descripcion { get; set; }
        //    public int Estado { get; set; }
        //    public int AnioFiscal { get; set; }
        //    public decimal PonderacionObjetivo { get; set; }
        //    public int IdResultado { get; set; }
        //    public string Nombre { get; set; }
        //    public string Indicador { get; set; }
        //    public int Tipo { get; set; }
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdResultado { get; set; }
        public SelectList IdResultadoList { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaFin { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Ponderacion { get; set; }
    }
}
