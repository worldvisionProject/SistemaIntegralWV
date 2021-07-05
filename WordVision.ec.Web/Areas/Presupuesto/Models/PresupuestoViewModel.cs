using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Presupuesto.Models
{
    public class PresupuestoViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public string T5 { get; set; }

        public string DescripcionT5 { get; set; }

        public decimal Precio { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }

        public int TipoCargo { get; set; }


        public int Mes { get; set; }
        public int TodoAnio { get; set; }

        public int MesIngreso { get; set; }
        public int AnioIngreso { get; set; }
    }

    public class AsignarViewModel
    {
        public string IdT5 { get; set; }
        public string Tipo { get; set; }

        public decimal ValUnitario { get; set; }
        public int Cantidad { get; set; }

        public decimal Total { get; set; }
        public int MesAnual { get; set; }

        public IEnumerable<DatosT5ViewModel> T5Combo { get; set; }

        public List<DatosLDRViewModel> LDRs { get; set; }

        public string Area { get; set; }
    }
}
