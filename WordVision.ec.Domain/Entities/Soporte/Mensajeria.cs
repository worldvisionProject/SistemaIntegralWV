using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class Mensajeria : AuditableEntity
    {
        //Estructura de Mensajeria
        [StringLength(150)]
        [Required]
        public string PersonaaContactar { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }
        [StringLength(10)]
        public string Celular { get; set; }
        public DateTime? FechaRequerida { get; set; }
        public byte[] Archivo { get; set; }
        public int TiposTramites { get; set; }
        [StringLength(500)]
        [Required]
        public string DescripcionTramite { get; set; }
        [StringLength(500)]
        [Required]
        public string Direccion { get; set; }
        [StringLength(500)]
        [Required]
        public string InformacionAdicional { get; set; }

        public int IdSolicitud { get; set; }
        public virtual Solicitud Solicitudes { get; set; }
    }
}
