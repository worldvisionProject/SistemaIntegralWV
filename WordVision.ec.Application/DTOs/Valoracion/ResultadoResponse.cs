using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Valoracion
{
    public class ResultadoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
       
        public string Indicador { get; set; }
       
        public int Tipo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
    }
}
