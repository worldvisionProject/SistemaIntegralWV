using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Indicadores
{
    public class DetalleDipInsumo : AuditableEntity
    {
        [StringLength(10)]
        public string CodigoInsumo { get; set; }

        [Required]
        [StringLength(250)]
        public string Insumo { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }

        public string Mes { get; set; }        

        public int IdDipInsumo { get; set; }
        [ForeignKey("IdDipInsumo")]
        public DipInsumo DipInsumo { get; set; }

        
    }
}
