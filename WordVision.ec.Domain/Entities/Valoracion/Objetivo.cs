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
    public class Objetivo : AuditableEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Estado { get; set; }
        [ForeignKey("IdObjetivo")]
        public ICollection<ObjetivoAnioFiscal> ObjetivoAnioFiscales { get; set; }

        [ForeignKey("IdResponsabilidad")]
        public ICollection<Responsabilidad> Responsabilidades { get; set; }

    }
}
