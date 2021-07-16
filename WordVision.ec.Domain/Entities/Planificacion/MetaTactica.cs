using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class MetaTactica : AuditableEntity
    {
        public int NumMeses { get; set; }
        public bool? Enero { get; set; }
        public bool? Febrero { get; set; }
        public bool? Marzo { get; set; }
        public bool? Abril { get; set; }
        public bool? Mayo { get; set; }
        public bool? Junio { get; set; }
        public bool? Julio { get; set; }
        public bool? Agosto { get; set; }
        public bool? Septiembre { get; set; }
        public bool? Octubre { get; set; }
        public bool? Noviembre { get; set; }
        public bool? Diciembre { get; set; }
        public int TipoMedida { get; set; }
        public decimal Valor { get; set; }
        public int IdIndicadorPOA { get; set; }
        
        public IndicadorPOA IndicadorPOAs { get; set; }
    }
}
