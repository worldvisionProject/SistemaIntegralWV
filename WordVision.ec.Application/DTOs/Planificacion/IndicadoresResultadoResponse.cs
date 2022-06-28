using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Planificacion
{
    public class IndicadoresResultadoResponse
    {
        public string FactorCritico { get; set; }
        public string IndicadorResultado { get; set; }
        public string Meta { get; set; }
        public int IdGestion { get; set; }
        public int IdFactorCritico { get; set; }
        public int IdIndicadorEstrategico { get; set; }
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public string DescCargoResponsable { get; set; }
        public int IdObjetivo { get; set; }
        public string IndicadorProducto { get; set; }
        public string DescripcionActividad { get; set; }
    }
}
