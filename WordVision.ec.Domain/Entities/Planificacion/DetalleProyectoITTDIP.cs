using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class DetalleProyectoITTDIP : AuditableEntity
    {
        public decimal Q1 { get; set; }

        public bool Octubre { get; set; }

        public bool Noviembre { get; set; }

        public bool Diciembre { get; set; }

        public decimal Q2 { get; set; }

        public bool Enero { get; set; }

        public bool Febrero { get; set; }

        public bool Marzo { get; set; }

        public decimal Q3 { get; set; }

        public bool Abril { get; set; }

        public bool Mayo { get; set; }

        public bool Junio { get; set; }

        public decimal Q4 { get; set; }

        public bool Julio { get; set; }

        public bool Agosto { get; set; }

        public bool Septiembre { get; set; }

        public decimal Anual { get; set; }

        public int IdLogFrame { get; set; }
        [ForeignKey("IdLogFrame")]
        public LogFrame LogFrame { get; set; }

        public int IdProyectoITTDIP { get; set; }
        [ForeignKey("IdProyectoITTDIP")]
        public ProyectoITTDIP ProyectoITTDIP { get; set; }
    }
}
