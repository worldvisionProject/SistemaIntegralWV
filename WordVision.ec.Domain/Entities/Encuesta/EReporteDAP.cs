using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EReporteDAPs", Schema = "survey")]
    public class EReporteDAP
    {
        public string rpt_Proyecto { get; set; }
        public string rpt_Programa { get; set; }
        public string rpt_LogFrame { get; set; }
        public string rpt_Objetivo { get; set; }
        public string rpt_IndicadorCodigo { get; set; }
        public string rpt_IndicadorNombre { get; set; }
        public string rpt_IndicadorTipo { get; set; }
        public decimal? rpt_Apoyo { get; set; }
        public decimal? rpt_Empoderamiento { get; set; }
        public decimal? rpt_Limite { get; set; }
        public decimal? rpt_UsoConstructivo { get; set; }
        public decimal? rpt_Compromiso { get; set; }
        public decimal? rpt_Valores { get; set; }
        public decimal? rpt_Competencia { get; set; }
        public decimal? rpt_Identidad { get; set; }


        public decimal rpt_numerador { get; set; }
        public decimal rpt_denominador { get; set; }
        public decimal rpt_porcentaje { get; set; }
        public decimal rpt_resultado { get; set; }



        public int rpt_Region { get; set; }
        public string rpt_Provincia { get; set; }
        public string rpt_Canton { get; set; }

    }
}
