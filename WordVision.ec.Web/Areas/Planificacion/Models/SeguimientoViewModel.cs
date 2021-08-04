using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class SeguimientoViewModel
    {
        public int Id { get; set; }
        public string PorcentajeCumplimiento { get; set; }
        public string ComentarioColaborador { get; set; }
        public string ComentarioSupervisor { get; set; }
        public string CompetenciasDessarrolladas { get; set; }
        public string Acciones { get; set; }

        public string Cumplimiento { get; set; }



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
    }
}
