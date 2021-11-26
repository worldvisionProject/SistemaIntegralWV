using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class Gestion : AuditableEntity
    {
        [StringLength(150)]
        [Display(Name = "Descripcion AF")]
        public string Descripcion { get; set; }
        [Display(Name = "Año Fiscal")]
        [StringLength(15)]
        public string Anio { get; set; }

        [StringLength(1)]
        [Display(Name = "Estado de AF")]
        public string Estado { get; set; }

        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public int IdEstrategia { get; set; }
        public EstrategiaNacional EstrategiaNacionales { get; set; }

        //[ForeignKey("IdGestion")]
        //public ICollection<Producto> Productos { get; set; }
    }
}
