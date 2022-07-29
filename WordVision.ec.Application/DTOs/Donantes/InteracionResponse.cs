using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Donantes
{
    public class InteracionResponse
    {
        public string Gestion { get; set; }

        public string Tipo { get; set; }

        public string Observacion { get; set; }

        public int IdDonante { get; set; }

        public string EstadoKitCourier { get; set; }

        public DateTime? FechaEntregaKit { get; set; }

        public string NumeroGuiaKit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
