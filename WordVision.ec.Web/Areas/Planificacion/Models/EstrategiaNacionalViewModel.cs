using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class EstrategiaNacionalViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
        public int IdEmpresa { get; set; }
        public string Estado { get; set; }
        public string FactorCritico { get; set; }
        public string Indicador { get; set; }
        public string DescEstado { get; set; }

        public SelectList EstadoList { get; set; }
        public SelectList AnioFiscalList { get; set; }
        
        //public SelectList DimensionesList { get; set; }
        public virtual List<GestionViewModel> Gestiones { get; set; }
        public virtual List<ObjetivoEstrategicoViewModel> ObjetivoEstrategicos { get; set; }
        public virtual List<IndicadorCicloEstrategicoViewModel> IndicadorCicloEstrategicos { get; set; }
        public string AnioGestion { get; set; }
        public string DescGestion { get; set; }
        public string EstadoGestion { get; set; }


        public string DescripcionO { get; set; }
        public string CategoriaO { get; set; }
        public string AreaPrioridadO { get; set; }
        public SelectList AreaPrioridadList { get; set; }
        public string DimensionO { get; set; }
        public int CargoResponsableO { get; set; }

        public int CategoriaObjetivo { get; set; }

        public string EsCoordinadorEstrategico { get; set; }
    }

    public class EstrategiaNacionalList
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

}
