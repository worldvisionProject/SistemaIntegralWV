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
    public class Recurso : AuditableEntity
    {
        [Required]
        public int CentroCosto { get; set; }
        [Required]
        public int CuentaCodigoCC { get; set; }
        [Required]
        public int CategoriaMercaderia { get; set; }
        [Required]
        public int Insumo { get; set; }
        public string ParaqueConsultoria { get; set; }
        [StringLength(1)]
        public string Gtrm { get; set; }
        public string JustificacionConsultoria { get; set; }
        [Required]
        public decimal? Cantidad { get; set; }
        [Required]
        public decimal? PrecioUnitario { get; set; }
        [Required]
        public decimal? Total { get; set; }

        public string DetalleInsumo { get; set; }


        public Actividad Actividades { get; set; }

        [ForeignKey("IdRecurso")]
        public ICollection<FechaCantidadRecurso> Recursos { get; set; }
    }
}
