using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.LogFrame;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITT
{
    public class DetalleProyectoITTResponse
    {
        public string LineBase { get; set; }

        public decimal MetaAF1 { get; set; }

        public decimal MetaAF2 { get; set; }

        public decimal MetaAF3 { get; set; }

        public decimal MetaAF4 { get; set; }

        public decimal MetaAF5 { get; set; }

        public decimal MetaAF6 { get; set; }

        public int IdLogFrame { get; set; }
        public LogFrameResponse LogFrame { get; set; }

        public int IdProyectoITT { get; set; }
        public ProyectoITTResponse ProyectoITT { get; set; }
    }
}
