using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Firma : AuditableEntity
    {
        public int IdColaborador { get; set; }
        public Colaborador Colaboradores { get; set; }

        [Required]
        public int IdDocumento { get; set; }

        [Required]
        public byte[] Image { get; set; }

    }
}
