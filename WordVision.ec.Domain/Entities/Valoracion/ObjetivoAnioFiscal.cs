using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class ObjetivoAnioFiscal : AuditableEntity
    {
        [Required]
        public int AnioFiscal { get; set; }
        [Required]
        public decimal Ponderacion { get; set; }
        public int IdObjetivo { get; set; }
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public Objetivo Objetivos { get; set; }

        [ForeignKey("IdObjetivoAnioFiscal")]
        public ICollection<PlanificacionResultado> PlanificacionResultados { get; set; }
        [ForeignKey("IdObjetivoAnioFiscal")]
        public ICollection<Resultado> Resultado { get; set; }
        [ForeignKey("IdObjetivoAnioFiscal")]
        public ICollection<Responsabilidad> Responsabilidades { get; set; }
    }
}
