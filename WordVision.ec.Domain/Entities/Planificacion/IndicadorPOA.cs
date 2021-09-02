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
    public class IndicadorPOA : AuditableEntity
    {
       
        [Required]
        public string IndicadorProducto { get; set; }
      
        [Required]
        public string MedioVerificacion { get; set; }
        [Required]
        public int? Responsable { get; set; }

        [Required]
        public int? UnidadMedida { get; set; }

        [Required]
        public decimal? LineaBase { get; set; }

        [Required]
        public decimal? Meta { get; set; }
        [StringLength(15)]
        public string Codigo { get; set; }
        public int Tipo { get; set; }
        public int Actor { get; set; }

        public int IdProducto { get; set; }
        public Producto Productos { get; set; }


        [ForeignKey("IdIndicadorPOA")]
        public ICollection<Actividad> Actividades { get; set; }

        [ForeignKey("IdIndicadorPOA")]
        public ICollection<MetaTactica> MetaTacticas { get; set; }
    }
}

