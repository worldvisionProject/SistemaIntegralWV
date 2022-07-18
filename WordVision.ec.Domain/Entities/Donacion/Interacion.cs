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

        public int Gestion  { get; set; }

        public int Tipo { get; set; }

        public string Observacion { get; set; }

        public int IdDonante { get; set; }

        public Donante Donantes { get; set; }
    }
}
