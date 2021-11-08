using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class Comunicacion : AuditableEntity
    {
        //public int NumSolicitud { get; set; }

        //public int TipoSolicitud { get; set; }

        //public int AreaSolicitante { get; set; }

        //public DateTime? FechaSolicitud { get; set; }
        //public decimal Presupuesto { get; set; }
        //public string DisponibilidadPresupuestaria { get; set; }
        //public string AutorizacióndelLíderInmediato { get; set; }
        //public string Informativo { get; set; }

        //public int Responsable { get; set; }

        //public int NumdeTicketTI { get; set; }

        //public string NombredelEvento { get; set; }
        //public DateTime? FechadelEvento { get; set; }
        //public DateTime? HoradelEvento { get; set; }

        //public string LugarEvento { get; set; }
        //public string ObjetivodelEvento { get; set; }
        //public string PúblicoObjetivo { get; set; }
        //public int NúmerodeParticipantesEstimado { get; set; }
        //public bool TransmisiónVirtual { get; set; }
        //public string GuionMinuto_a_MinutoEvento { get; set; }
        //public string LogosSociosInvolucrados { get; set; }
        //public string PersonasAutoridadesAsistirán { get; set; }
        //public string PersonalWVInvolucrado { get; set; }
        //public string SituacionesInteresParaWorldVision { get; set; }

        //public string SociosQuienesInteractuar { get; set; }
        //public DateTime? FechaRequiereProducto { get; set; }
        //public string DescripciónProducto { get; set; }
        //public string ObjetivoProducto { get; set; }
        //public string PublicoObjetivo { get; set; }
        //public string MensajeClave { get; set; }
        //public string DocumentoBasedeTrabajo { get; set; }


        [Required]
        public int TipoSolicitud { get; set; }
        [Required]
        public DateTime? FechaSolicitud { get; set; }
        [Required]
        public decimal Presupuesto { get; set; }
        [Required]
        public byte[] DisponibilidadPresupuestaria { get; set; }
        [Required]
        public byte[] AutorizaciondelLider { get; set; }

        //public string Informativo { get; set; }

        //public int Responsable { get; set; }

        //public int NumdeTicketTI { get; set; }
        [StringLength(250)]
        [Required]
        public string NombreEvento { get; set; }
        [Required]
        public DateTime FechaEvento { get; set; }
        [Required]
        public DateTime? HoraEvento { get; set; }
        [StringLength(250)]
        public string LugarEvento { get; set; }
        [StringLength(550)]
        [Required]
        public string ObjetivoEvento { get; set; }
        [StringLength(250)]
        [Required]
        public string PublicoObjetivo { get; set; }
        public int NumeroParticipantes { get; set; }
        public bool TransmisionVirtual { get; set; }
        public byte[] GuionEvento { get; set; }
        public string LogosSocios { get; set; }
        public string PersonasAsistiran { get; set; }
        public string PersonalWV { get; set; }
        public string SituacionesInteresWV { get; set; }

        public string SociosInteractuar { get; set; }
        //public DateTime? FechaRequiereProducto { get; set; }
        //public string DescripciónProducto { get; set; }
        //public string ObjetivoProducto { get; set; }
        //public string PublicoObjetivo { get; set; }
        public string MensajeClave { get; set; }
        public string DocumentoBase { get; set; }

        public int IdSolicitud { get; set; }
        public virtual Solicitud Solicitudes { get; set; }

        [ForeignKey("IdComunicacion")]
        public Ponente Ponentes { get; set; }
        [ForeignKey("IdComunicacion")]
        public LogoSocio LogoSocios { get; set; }
    }
}
