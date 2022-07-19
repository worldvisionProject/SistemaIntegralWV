using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EReporteDAPViewModel
    {
        [Display(Name = "Proyecto")]
        public string rpt_Proyecto { get; set; }
        [Display(Name = "Programa")]
        public string rpt_Programa { get; set; }
        [Display(Name = "Log Frame")]
        public string rpt_LogFrame { get; set; }
        [Display(Name = "Objetivo")]
        public string rpt_Objetivo { get; set; }
        [Display(Name = "Código Indicador")]
        public string rpt_IndicadorCodigo { get; set; }
        [Display(Name = "Indicador")]
        public string rpt_IndicadorNombre { get; set; }
        [Display(Name = "Tipo")]
        public string rpt_IndicadorTipo { get; set; }
        [Display(Name = "Apoyo")]
        public decimal? rpt_Apoyo { get; set; }
        [Display(Name = "Empoderamiento")]
        public decimal? rpt_Empoderamiento { get; set; }
        [Display(Name = "Límite")]
        public decimal? rpt_Limite { get; set; }
        [Display(Name = "Uso Constructivo")]
        public decimal? rpt_UsoConstructivo { get; set; }
        [Display(Name = "Compromiso")]
        public decimal? rpt_Compromiso { get; set; }
        [Display(Name = "Valores")]
        public decimal? rpt_Valores { get; set; }
        [Display(Name = "Competencia")]
        public decimal? rpt_Competencia { get; set; }
        [Display(Name = "Identidad")]
        public decimal? rpt_Identidad { get; set; }


        [Display(Name = "Numerador")] 
        public decimal rpt_numerador { get; set; }
        [Display(Name = "Denominador")]
        public decimal rpt_denominador { get; set; }
        [Display(Name = "Porcentaje")]
        public decimal rpt_porcentaje { get; set; }
        [Display(Name = "Resultado")]
        public decimal rpt_resultado { get; set; }




        [Display(Name = "Región")] 
        public int rpt_Region { get; set; }
        [Display(Name = "Provincia")]
        public string rpt_Provincia { get; set; }
        [Display(Name = "Cantón")]
        public string rpt_Canton { get; set; }
        [Display(Name = "Parroquia")]
        public string rpt_Parroquia { get; set; }






    }
}
