using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class Ponente : AuditableEntity
    {
        public string NombreApellido { get; set; }
        public string Cargo { get; set; }

        public string Perfil { get; set; }
        public string Tema { get; set; }
    }
}
