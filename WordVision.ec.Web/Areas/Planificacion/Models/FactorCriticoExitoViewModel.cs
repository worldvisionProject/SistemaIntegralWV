using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class FactorCriticoExitoViewModel
    {
        public int Id { get; set; }
        public string FactorCritico { get; set; }
        public int IdObjetivoEstra { get; set; }
        public virtual List<IndicadorEstrategico> IndicadorEstrategicos { get; set; }

    }
}
