﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class Responsabilidad : AuditableEntity
    {
        [Required]
        public int IdEstructura { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EsObligatorio { get; set; }
        [Required]
        public string Indicador { get; set; }
        [Required]
        public int Tipo { get; set; }
        [Required]
        public int IdResponsabilidad { get; set; }
        [Required]
        public int Padre { get; set; }

        public int IdObjetivoAnioFiscal { get; set; }
        public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }

        //public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }
        //[ForeignKey("IdResponsabilidad")]
        //public ICollection<PlanificacionResponsabilidad> PlanificacionResponsabilidades { get; set; }
    }
}
