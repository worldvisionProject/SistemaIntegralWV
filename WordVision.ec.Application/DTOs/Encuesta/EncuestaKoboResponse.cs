using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Encuesta
{
    public class EncuestaKoboAPIResponse
    {
        public int Id { get; set; }
        public string id_string { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }
}
