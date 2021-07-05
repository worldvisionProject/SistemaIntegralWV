using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetAllCached
{
    public class GetAllDatosLDRsCachedResponse
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
    }
}
