using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Tercero : AuditableEntity
    {

        [StringLength(1)]
        [Required]
        public string Tipo { get; set; }
        [StringLength(13)]
        public string Identificacion { get; set; }
        [StringLength(150)]
        [Required]
        public string PrimerApellido { get; set; }
        [StringLength(150)]
        [Required]
        public string SegundoApellido { get; set; }
        [StringLength(150)]
        [Required]
        public string PrimerNombre { get; set; }
        [StringLength(150)]
        [Required]
        public string SegundoNombre { get; set; }

        //[Required]
        public DateTime? FecNacimiento { get; set; }

        //[Required]
        [StringLength(1)]
        public string? Genero { get; set; }

        public DateTime? VigDesde { get; set; }
        public DateTime? VigHasta { get; set; }

        [StringLength(5)]
        public string CodigoArea { get; set; }
        [StringLength(20)]
        public string Telefono { get; set; }
        [StringLength(20)]
        public string Celular { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        public byte[] ImageCedula { get; set; }

        [ForeignKey("IdTecero")]
        public virtual ICollection<FormularioTercero> FormularioTerceros { get; set; }



    }
}
