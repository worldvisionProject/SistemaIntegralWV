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
    public class ObjetivoEstrategico : AuditableEntity
    {
        public string Programa { get; set; }
        public string Cwbo { get; set; }

        [Required]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(1)]
        public int Categoria { get; set; }
                  
        public int? AreaPrioridad { get; set; }
   
        public int? Dimension { get; set; }

        [Required]
        public int CargoResponsable { get; set; }

        public int IdEstrategia { get; set; }
        public EstrategiaNacional EstrategiaNacionales { get; set; }

        [ForeignKey("IdObjetivoEstra")]
        public ICollection<FactorCriticoExito> FactorCriticoExitos { get; set; }

        [ForeignKey("IdObjetivoEstra")]
        public ICollection<ProductoObjetivo> ProductoObjetivos { get; set; }

    }
}
