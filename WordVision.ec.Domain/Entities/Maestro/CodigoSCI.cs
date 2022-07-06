using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class CodigoSCI : AuditableEntity
    {
        [StringLength(500)]
        [Required]
        public string NombreBanco { get; set; }

        [StringLength(10)]
        [Required]
        public string CodigoBanco { get; set; }

        public int EstadoBanco { get; set; }


        public int IdEmpresa { get; set; }
        public Empresa Empresas { get; set; }
    }
}
