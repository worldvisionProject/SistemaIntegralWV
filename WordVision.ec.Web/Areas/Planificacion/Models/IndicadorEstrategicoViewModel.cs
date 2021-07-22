using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorEstrategicoViewModel
    {
        public int Id { get; set; }
        public string IndicadorResultado { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        // [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string LineaBase { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta { get; set; }
        public int IdFactorCritico { get; set; }
        public int IdEstrategia { get; set; }
        public int IdGestion { get; set; }
        public SelectList gestionList { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string MetaAF { get; set; }
        public string EntregableAF { get; set; }
        public SelectList NumMesesList { get; set; }
        public SelectList UnidadList { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string ValorMeta { get; set; }
        public string EntregableMeta { get; set; }
        public virtual List<IndicadorAFViewModel> IndicadorAFs { get; set; }
        public virtual List<MetaViewModel> MetaEstrategicas { get; set; }

        public virtual List<ProductoViewModel> Productos { get; set; }
    }
}
