using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Donacion
{
    public class Interacion : AuditableEntity
    {

        public int Interaciones  { get; set; }

        public int Tipo { get; set; }

        public string Observacion { get; set; }

        public Donante Donantes { get; set; }
    }
}
