using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class LogoSocio : AuditableEntity
    {
        [StringLength(150)]
        public string Socio { get; set; }
        [Required]
        public byte[] Logo { get; set; }
        public int IdComunicacion { get; set; }
        public virtual Comunicacion Comunicaciones { get; set; }
    }
}
