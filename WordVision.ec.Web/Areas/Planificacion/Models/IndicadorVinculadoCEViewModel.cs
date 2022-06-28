using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class IndicadorVinculadoCEViewModel 
    {
        public int Id { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public int ActorParticipante { get; set; }
        public SelectList TipoIndicadorList { get; set; }
        public SelectList CodigoIndicadorList { get; set; }
        public SelectList UnidadMedidaList { get; set; }
        public SelectList ActorParticipanteList { get; set; }
        public int IdIndicadorCicloEstrategico { get; set; }
        public IndicadorCicloEstrategicoViewModel IndicadorCicloEstrategicos { get; set; }
    }
}
