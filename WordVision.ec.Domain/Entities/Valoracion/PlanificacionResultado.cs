﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class PlanificacionResultado : AuditableEntity
    {
       
        public int IdColaborador { get; set; }
        [Required]
        public int IdResultado { get; set; }
        
        public decimal? Meta { get; set; }
       
        public DateTime? FechaInicio { get; set; }
      
        public DateTime? FechaFin { get; set; }
       
        public decimal? Ponderacion { get; set; }
        public Resultado Resultados { get; set; }
    }
}
