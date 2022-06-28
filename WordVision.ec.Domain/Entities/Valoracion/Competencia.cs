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
    public class Competencia : AuditableEntity
    {
        [Required]
        public int IdNivel { get; set; }
        [Required]
        public string NombreCompetencia { get; set; }
        public string Descripcion { get; set; }
        public int EsObligatorio { get; set; }
        [Required]
        public string Comportamiento { get; set; }
        [Required]
        public int IdCompetencia { get; set; }
        [Required]
        public int Padre { get; set; }
        //[Required]
        //public int Tipo { get; set; }
        //public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }
        //[ForeignKey("IdResponsabilidad")]
        //public ICollection<PlanificacionResponsabilidad> PlanificacionResponsabilidades { get; set; }
    }
}
