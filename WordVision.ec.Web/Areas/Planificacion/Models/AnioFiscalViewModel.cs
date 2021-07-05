using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class AnioFiscalViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Causa { get; set; }
        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
      public string Estado { get; set; }

        public string AnioGestion { get; set; }
        public string DescGestion { get; set; }
        public string EstadoGestion { get; set; }


        public string DescripcionO { get; set; }
        public string CategoriaO { get; set; }
        public string AreaPrioridadO { get; set; }
        public string DimensionO { get; set; }
        public int CargoResponsableO { get; set; }


        public ICollection<GestionViewModel> Gestiones { get; set; }
        public ICollection<ObjetivoEstrategicoViewModel> ObjetivoEstrategicos { get; set; }
    }
}
