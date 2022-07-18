using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Donantes
{
    public class DonanteResponse
    {
        public int Id { get; set; }
        public string Campana { get; set; }
        public string Donante { get; set; }
        public string Cedula { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public decimal Cantidad { get; set; }
    }
}
