using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class Escala : AuditableEntity
    {
        [Required]
        public string Calificacion { get; set; }
        [Required]
        public string Definicion { get; set; }
        [Required]
        public decimal EscalaInicio { get; set; }
        [Required]
        public decimal EscalaFin { get; set; }
    }
}
