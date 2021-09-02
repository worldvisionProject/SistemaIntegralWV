using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class IndicadorEstrategico : AuditableEntity
    {
       
        [Required]
        public string IndicadorResultado { get; set; }
      
        [Required]
        public string MedioVerificacion { get; set; }
        [Required]
        public int? Responsable { get; set; }

        [Required]
        public int? UnidadMedida { get; set; }

        [Required]
        public decimal? LineaBase { get; set; }

        public decimal? Meta { get; set; }

        public string EntregableAnual { get; set; }
        [StringLength(15)]
        public string Codigo { get; set; }
        public int Tipo { get; set; }
        public int Actor { get; set; }

        public int IdFactorCritico { get; set; }
        public FactorCriticoExito FactorCriticoExitos { get; set; }

        [ForeignKey("IdIndicadorEstrategico")]
        public ICollection<Producto> Productos { get; set; }

        [ForeignKey("IdIndicadorEstrategico")]
        public ICollection<IndicadorAF> IndicadorAFs { get; set; }

        [ForeignKey("IdIndicadorEstrategico")]
        public ICollection<MetaEstrategica> MetaEstrategicas { get; set; }

    }
}

