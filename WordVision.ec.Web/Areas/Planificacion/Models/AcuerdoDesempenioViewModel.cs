using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class AcuerdoDesempenioViewModel
    {
        public int Id { get; set; }
        public string AccionEstrategica { get; set; }
        public int? Nivel { get; set; }
        public int? Competencia { get; set; }
        public int? Comportamiento { get; set; }
        public string PorQue { get; set; }
    }


    public class AcuerdoViewModel
    {
        public string Objetivo { get; set; }
        public string Factor { get; set; }
        public string IndicadorEstrategico { get; set; }
        public string MetaEstrategico { get; set; }
        public string Producto { get; set; }
        public string Meta { get; set; }
     
    }
}
