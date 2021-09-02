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
    public class ProductoObjetivo : AuditableEntity
    {
        [Required]
        public string Producto { get; set; }
        public int IdObjetivoEstra { get; set; }
        public ObjetivoEstrategico ObjetivoEstrategicos { get; set; }
        
        [ForeignKey("IdProductoObjetivo")]
        public ICollection<IndicadorProductoObjetivo> IndicadorProductoObjetivos { get; set; }
    }
}
