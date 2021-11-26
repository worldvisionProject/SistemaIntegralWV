using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class Actividad : AuditableEntity
    {
        public string DescripcionActividad { get; set; }
        [Required]
        public string Entregable { get; set; }
        [Required]
        public int IdCargoResponsable { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public decimal? Ponderacion { get; set; }
        [StringLength(1)]
        public string SNPresupuesto { get; set; }
        public decimal? TechoPresupuestoCC { get; set; }
        public decimal? TotalRecurso { get; set; }
        public decimal? Saldo { get; set; }
        public int IdIndicadorPOA { get; set; }
        public IndicadorPOA IndicadorPOAs { get; set; }

        [ForeignKey("IdActividad")]
        public ICollection<Recurso> Recursos { get; set; }
    }
}
