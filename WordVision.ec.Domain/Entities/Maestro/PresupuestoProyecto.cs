using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class PresupuestoProyecto : AuditableEntity
    {
        public decimal Total { get; set; }

        public decimal CostoSoporte { get; set; }

        [Required]
        public decimal Nomina { get; set; }

        [Required]
        public decimal TI { get; set; }

        [Required]
        public decimal Administracion { get; set; }

        [Required]
        public decimal LineamientosOnAdmistrativos { get; set; }

        [Required]
        public decimal LineamientosOnOperativos { get; set; }

        [Required]
        public decimal TechoPresupuestario { get; set; }

        public int IdProgramaArea { get; set; }
        [ForeignKey("IdProgramaArea")]
        public ProgramaArea ProgramaArea { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }
    }
}
