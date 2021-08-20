using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class SeguimientoViewModel
    {
        public int Id { get; set; }
        public int IdIndicador { get; set; }
         public string Tipo { get; set; }
        public int Mes { get; set; }
         public string Avance { get; set; }
         public decimal? PorcentajeAvance { get; set; }

        public string RutaAdjunto { get; set; }
        public string NombreAdjunto { get; set; }
        public string AvanceCompetencia { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public string DescObjetivo { get; set; }
        public string DescFactor { get; set; }
        public string DescIndicador { get; set; }
        public string DescMeta { get; set; }
        public string ResponsableIndicador { get; set; }
        public string DescGestion { get; set; }
        public string DescLineaBase { get; set; }
        public string DescResponsable { get; set; }
        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public string IndicadorProducto { get; set; }
        public string DescMes { get; set; }

        public virtual List<MetaViewModel> MetaEstrategicas { get; set; }
        public SelectList NumMesesList { get; set; }
    }
}
