using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        public int Estado { get; set; }

        [ForeignKey("IdPais")]
        public ICollection<Provincia> Provincias { get; set; }
    }
}
