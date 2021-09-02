using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class TableroControlViewModel
    {
        public int IdObjetivoEstrategico { get; set; }

        public int IdFactor { get; set; }
        public string DescFactor { get; set; }
        public int IdIndicadorEstrategico { get; set; }
        public string DescIndicadorEstrategico { get; set; }
        public int IdRespIndicadorEstrategico { get; set; }
        public string RespIndicadorEstrategico { get; set; }
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public int IdRespProducto { get; set; }
        public string RespProducto { get; set; }
        public int IdIndicadorProducto { get; set; }
        public string DescIndicadorProducto { get; set; }
        public int IdRespIndicadorProducto { get; set; }
        public string RespIndicadorProducto { get; set; }
        public int IdActividad { get; set; }
        public string DescActividad { get; set; }
        public int IdRespActividad { get; set; }
        public string RespActividad { get; set; }
    }
}
