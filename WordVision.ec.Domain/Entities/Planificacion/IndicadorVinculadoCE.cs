﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class IndicadorVinculadoCE : AuditableEntity
    {
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public int ActorParticipante { get; set; }
        public int IdIndicadorCicloEstrategico { get; set; }
        public IndicadorCicloEstrategico IndicadorCicloEstrategicos { get; set; }
    }
}
