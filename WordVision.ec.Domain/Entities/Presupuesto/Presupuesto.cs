using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Presupuesto
{
    public class Presupuesto : AuditableEntity
    {
        [Required]
        public string Tipo { get; set; }

        [StringLength(50)]
        public string T5 { get; set; }

        [StringLength(150)]
        public string DescripcionT5 { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public int TipoCargo { get; set; }


        public int Mes { get; set; }
        public int TodoAnio { get; set; }

        public int MesIngreso { get; set; }
        public int AnioIngreso { get; set; }
    }
}
