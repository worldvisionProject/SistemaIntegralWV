using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("EReporteConsolidados", Schema = "survey")]
    
    public class EReporteConsolidado
    {
        public string rpt_Proyecto { get; set; }
        public string rpt_Programa { get; set; }
        public string rpt_LogFrame { get; set; }
        public string rpt_Objetivo { get; set; }
        public string rpt_IndicadorCodigo { get; set; }
        public string rpt_IndicadorNombre { get; set; }
        public string rpt_UnidadMedida { get; set; }
        public string rpt_Frecuencia { get; set; }
        public decimal? rpt_LineaBaseResultado { get; set; }
        public decimal? rpt_Anio4_meta { get; set; }
        public decimal? rpt_Anio4_ejec { get; set; }
        public decimal? rpt_Anio5_meta { get; set; }
        public decimal? rpt_Anio5_ejec { get; set; }
        public decimal? rpt_Anio6_meta { get; set; }
        public decimal? rpt_Anio6_ejec { get; set; }
        public decimal? rpt_Total_meta { get; set; }
        public decimal? rpt_Total_ejec { get; set; }


        public int rpt_Region { get; set; }
        public string rpt_Provincia { get; set; }
        public string rpt_Canton { get; set; }
        public string rpt_Parroquia { get; set; }

    }
}
