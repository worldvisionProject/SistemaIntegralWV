using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.LogFrame;

namespace WordVision.ec.Application.Features.Indicadores.DipInsumo
{
    public class DetalleDipInsumoResponse
    {
        public string CodigoInsumo { get; set; }
        public string Insumo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public string Mes { get; set; }
        public int IdDipInsumo { get; set; }
        public DipInsumoResponse DipInsumo { get; set; }
    }
}
