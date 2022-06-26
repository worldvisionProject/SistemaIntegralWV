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
    public class RCNinoPatrocinado : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string Comunidad { get; set; }
        public int Edad { get; set; }
        public bool Patrocinado { get; set; }

        public int IdGrupoEtario { get; set; }
        [ForeignKey("IdGrupoEtario")]
        public DetalleCatalogo GrupoEtario { get; set; }

        public int IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public DetalleCatalogo Genero { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

        public int IdProgramaArea { get; set; }
        [ForeignKey("IdProgramaArea")]
        public ProgramaArea ProgramaArea { get; set; }
    }
}
