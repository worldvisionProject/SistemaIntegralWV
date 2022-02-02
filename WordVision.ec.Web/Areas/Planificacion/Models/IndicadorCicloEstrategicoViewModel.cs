using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorCicloEstrategicoViewModel
    {
        public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Logro { get; set; }
        public int AnioFiscal { get; set; }
        public SelectList AnioFiscalList { get; set; }
        public int IdEstrategia { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public int ActorParticipante { get; set; }
        public SelectList TipoIndicadorList { get; set; }
        public SelectList CodigoIndicadorList { get; set; }
        public SelectList UnidadMedidaList { get; set; }
        public SelectList ActorParticipanteList { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string LineBase { get; set; }

        public int AnioFiscal2 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta2 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Logro2 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string LineBase2 { get; set; }

        public int AnioFiscal3 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta3 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Logro3 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string LineBase3 { get; set; }

        public int AnioFiscal4 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta4 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Logro4 { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string LineBase4 { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string MetaAcumulada { get; set; }
        public ICollection<MetaCicloEstrategicoViewModel> MetaCicloEstrategicos { get; set; }
    }

    public class IndicadorCicloEstrategicoViewModelMaster
    {
        public SelectList AnioFiscalList { get; set; }
        public List<IndicadorCicloEstrategicoViewModel> IndicadorCicloEstrategicoViewModel { get; set; }
    }
}
