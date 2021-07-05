using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Dashboard.Models
{
    public class RegistroDashBoardViewModel
    {
        public int Id { get; set; }
        public decimal totalUsuario { get; set; }
        public decimal porcentajeIngreso { get; set; }
        public decimal pendientes { get; set; }
        public decimal documentosClaves { get; set; }
        public decimal politicas { get; set; }


    }
}
