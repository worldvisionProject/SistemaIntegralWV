using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel;


namespace WordVision.ec.Domain.Entities.Encuesta
{
    [Table("ETabulados", Schema = "survey")]
    public class ETabulado
    {
        public string CodigoIndicador { get; set; }
        public string CodigoPA { get; set; }
        public string PA { get; set; }
        public string Indicador { get; set; }
        public string TipoIndicador { get; set; }
        public int NumeroTotal { get; set; }
        public int EntrevistadosTotal { get; set; }
        public decimal? Porcentaje { get; set; }
        public decimal Result { get; set; }
        public int CodigoRegion { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoCanton { get; set; }

    }
}
