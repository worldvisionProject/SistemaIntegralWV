using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class PerfilDesempenioViewModel
    {
        public int Id { get; set; }
        public int TipoObjetivo { get; set; }
        public string Objetivo { get; set; }
        public string FactorExito { get; set; }
        public string Indicador { get; set; }
        public string MedioVerificacion { get; set; }
        public string Accion
        {
            get; set;
        }

        public string ResponsabilidadCargo { get; set; }
        public SelectList ResponsabilidadCargoList { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        // [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string LineaBase { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string MetaAnual { get; set; }
        public SelectList NumMesesList { get; set; }
        public SelectList UnidadList { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string ValorMeta { get; set; }
        public string EntregableMeta { get; set; }


        public virtual List<MetaViewModel> MetaTacticas { get; set; }

    }

    public class EvidenciaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }
        public string Descripcion { get; set; }


    }
}
