using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Presupuesto.Models
{
    public class DatosLDRViewModel
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }

        public string Ubicacion { get; set; }
        public string T0 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
        public string FijoEventual { get; set; }
        public decimal Ldr { get; set; }

        public bool select { get; set; }

        public decimal TotalGasto { get; set; }
        public decimal PorceImputado { get; set; }
        public decimal ValorImputado { get; set; }

        public int MesIngreso { get; set; }
        public int AnioIngreso { get; set; }
    }

    public class DatosLDRLoadViewModel
    {
       
        public string Cedula { get; set; }
        public string Ubicacion { get; set; }
        public string T0 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
        public string Fijo { get; set; }
        public string Eventual { get; set; }
        public decimal Ldr { get; set; }

       
    }
}
