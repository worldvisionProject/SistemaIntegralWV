using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class RespuestaViewModel
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdDocumento { get; set; }
        public int IdPregunta { get; set; }
        public string DescRespuesta { get; set; }

    }
}
