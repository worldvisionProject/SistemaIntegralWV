using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class Producto : AuditableEntity
    {

        //public int IdObjetivoEstra { get; set; }
        //[Required]
        //public int IdIndicadorEstrategico { get; set; }

        //[Required]
        //public string IdCategoria { get; set; }
        [Required]
        public string DescProducto { get; set; }

        [Required]
        public int IdCargoResponsable { get; set; }

        public int IdIndicadorEstrategico { get; set; }
        public IndicadorEstrategico IndicadorEstrategicos { get; set; }

        public int IdGestion { get; set; }
        //public Gestion Gestiones { get; set; }

        [ForeignKey("IdProducto")]
        public ICollection<IndicadorPOA> IndicadorPOAs { get; set; }
    }
}
