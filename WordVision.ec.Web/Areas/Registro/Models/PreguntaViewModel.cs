using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class PreguntaViewModel
    {
        public int Id { get; set; }
        public int NumPregunta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAcepto { get; set; }
        public string DescripcionUrl1 { get; set; }
        public string Url1 { get; set; }
        public string DescripcionUrl2 { get; set; }
        public string Url2 { get; set; }
        public string DescripcionUrl3 { get; set; }
        public string Url3 { get; set; }
        public string Estado { get; set; }

        public int IdDocumento { get; set; }
    }
}
