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
    public class PlanificacionResultado : AuditableEntity
    {
       
        public int IdColaborador { get; set; }
        public int ReportaId { get; set; }
        [Required]
        public int IdResultado { get; set; }
        
        public decimal? Meta { get; set; }
       
        public DateTime? FechaInicio { get; set; }
      
        public DateTime? FechaFin { get; set; }
       
        public decimal? Ponderacion { get; set; }

        public string DatoManual1 { get; set; }

        public string DatoManual2 { get; set; }
        public int DatoManual3 { get; set; }
        //public Resultado Resultados { get; set; }
        [Required]
        public int TipoObjetivo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public int Estado { get; set; }
        public string ObservacionLider { get; set; }
        public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }
        
        [ForeignKey("IdPlanificacion")]
        public ICollection<PlanificacionHito> PlanificacionHitos { get; set; }
    }
}
