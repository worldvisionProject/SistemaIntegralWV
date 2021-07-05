using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Domain.Entities.Registro
{
    public class Colaborador: AuditableEntity
    {
        [StringLength(500)]
        [Required]
        public string Apellidos { get; set; }

        [StringLength(500)]
        [Required]
        public string ApellidoMaterno { get; set; }

        [StringLength(150)]
        [Required]
        public string PrimerNombre { get; set; }

        [StringLength(150)]
        [Required]
        public string SegundoNombre { get; set; }

        [StringLength(13)]
        [Required]
        public string Identificacion { get; set; }

        [StringLength(150)]
        [Required]
        public string Email { get; set; }

        [StringLength(500)]
        [Required]
        public string Cargo { get; set; }

        [StringLength(500)]
        [Required]
        public string Area { get; set; }

        [StringLength(500)]
        [Required]
        public string LugarTrabajo { get; set; }
     
        [StringLength(100)]
        public string Alias { get; set; }


        [ForeignKey("IdColaborador")]
        public ICollection<Respuesta> Respuestas { get; set; }

        [ForeignKey("IdColaborador")]
        public ICollection<Firma> Firmas { get; set; }

        [ForeignKey("IdColaborador")]
        public virtual ICollection<Formulario> Formularios { get; set; }

        public int IdEstructura { get; set; }
        //public Estructura Estructuras { get; set; }

    }
}
