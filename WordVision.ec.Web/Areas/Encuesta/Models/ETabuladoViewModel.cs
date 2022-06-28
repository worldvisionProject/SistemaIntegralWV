using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class ETabuladoViewModel
    {
        [Display(Name = "Código")]
        public string CodigoIndicador { get; set; }

        [Display(Name = "PA")]
        public string PA { get; set; }
        
        [Display(Name = "Indicador")] 
        public string Indicador { get; set; }

        [Display(Name = "Número")]
        public int NumeroTotal { get; set; }

        [Display(Name = "Entrevistados")]
        public int EntrevistadosTotal { get; set; }

        [Display(Name = "% Porcentaje")]
        public decimal? Porcentaje { get; set; }

        [Display(Name = "Resultado")]
        public decimal Result { get; set; }
    }
}
