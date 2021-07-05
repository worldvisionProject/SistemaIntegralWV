using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Registro.DashBoards.Queries.GetAllDashBoards
{
    public class GetDashBoardsResponse
    {
        public int Id { get; set; }
        public decimal totalUsuario { get; set; }
        public decimal porcentajeIngreso { get; set; }
        public decimal pendientes { get; set; }
        public decimal documentosClaves { get; set; }
        public decimal politicas { get; set; }


    }
}
