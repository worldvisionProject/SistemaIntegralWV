using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorPOAViewModel
    {
        public string DescObjetivo { get; set; }
        public string DescFactor { get; set; }
        public string DescIndicador { get; set; }
        public string DescMeta { get; set; }
        public string ResponsableIndicador { get; set; }
        public string DescGestion { get; set; }
        public string DescLineaBase { get; set; }

        public int Id { get; set; }
        public string IndicadorProducto { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public string DescResponsable { get; set; }
        public SelectList responsableList { get; set; }
        public int? UnidadMedida { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        // [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string LineaBase { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta { get; set; }

        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string LineaBaseMeta { get; set; }
        public SelectList NumMesesList { get; set; }
        public SelectList UnidadList { get; set; }
        public string DescUnidad { get; set; }
      
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string ValorMeta { get; set; }
        public string EntregableMeta { get; set; }


        public int IdProducto { get; set; }
        public string DescProducto { get; set; }
        public virtual List<ActividadViewModel> Actividades { get; set; }

        public virtual List<MetaViewModel> MetaTacticas { get; set; }

        public ProductoViewModel Productos { get; set; }

        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int IdCargoResponsable { get; set; }
        public DateTime? Plazo { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string TechoPresupuestoCC { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string Saldo { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]

        public string Ponderacion { get; set; }


        public int IdIndicadorEstrategia { get; set; }
        public int IdGestion { get; set; }
        public int IdResponsablePOA { get; set; }

        public int TipoMeta { get; set; }
        public int Codigo { get; set; }
        public int Tipo { get; set; }
        public int Actor { get; set; }
        public int? Seleccionado { get; set; }

        public SelectList TipoIndicadorList { get; set; }
        public SelectList CodigoIndicadorList { get; set; }
        public SelectList ActorParticipanteList { get; set; }
        public SelectList TipoMetaList { get; set; }
        public int? TipoIndicadorVinculo { get; set; }
        public int? CodigoIndicadorVinculo { get; set; }
        public int? UnidadMedidaVinculo { get; set; }
        public int? ActorParticipanteVinculo { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string LogroAcumulado { get; set; }
        public ICollection<IndicadorVinculadoPOAViewModel> IndicadorVinculadoPOAs { get; set; }
    }
}
