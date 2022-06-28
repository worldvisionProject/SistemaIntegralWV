﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class OtroIndicador : AuditableEntity
    {
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(500)]
        public string Asunciones { get; set; }

        public int IdFrecuencia { get; set; }
        [ForeignKey("IdFrecuencia")]
        public DetalleCatalogo Frecuencia { get; set; }

        public int IdTipoIndicador { get; set; }
        [ForeignKey("IdTipoIndicador")]
        public DetalleCatalogo TipoIndicador { get; set; }

        public int IdTipoMedida { get; set; }
        [ForeignKey("IdTipoMedida")]
        public DetalleCatalogo TipoMedida { get; set; }

        public int IdActorParticipante { get; set; }
        [ForeignKey("IdActorParticipante")]
        public ActorParticipante ActorParticipante { get; set; }

        public int IdArea { get; set; }
        [ForeignKey("IdArea")]
        public DetalleCatalogo Area { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }
    }
}
