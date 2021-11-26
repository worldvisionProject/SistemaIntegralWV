using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class ComunicacionViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tipo de Solucitud")]
        [Required(ErrorMessage = "Tipo de Solucitud requerida.")]
        public int TipoSolicitud { get; set; }
        //public DateTime? FechaSolicitud { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingrese un valor decimal")]
        [Required(ErrorMessage = "Presupuesto requerido.")]
        public string Presupuesto { get; set; }

        [Display(Name = "Disponibilidad presupuestaria")]
        public byte[] DisponibilidadPresupuestaria { get; set; }
        [Display(Name = "Autorizacion del lider")]
        public byte[] AutorizaciondelLider { get; set; }
        //public string Informativo { get; set; }

        //public int Responsable { get; set; }

        //public int NumdeTicketTI { get; set; }
        [Display(Name = "Nombre del evento")]
        [Required(ErrorMessage = "Nombre del evento requerido.")]
        public string NombreEvento { get; set; }
        [Display(Name = "Fecha del evento")]
        [Required(ErrorMessage = "Fecha del evento requerido.")]
        public DateTime FechaEvento { get; set; }
        [Display(Name = "Hora del evento")]
        [Required(ErrorMessage = "Hora requerida.")]
        public string HoraEvento { get; set; }
        [Display(Name = "Lugar del evento")]
        [Required(ErrorMessage = "Lugar del evento requerida.")]
        public string LugarEvento { get; set; }
        [Display(Name = "Objetivo del evento")]
        [Required(ErrorMessage = "Objetivo del evento requerida.")]
        public string ObjetivoEvento { get; set; }
        [Display(Name = "Público objetivo")]
        [Required(ErrorMessage = "Público objetivo requerida.")]
        public string PublicoObjetivo { get; set; }
        [Display(Name = "Num. participantes")]
        [Required(ErrorMessage = "Num. participantes requerida.")]
        public int? NumeroParticipantes { get; set; }
        [Required(ErrorMessage = "Num. participantes requerida.")]
        public int? NumeroParticipantesP { get; set; }

        [Display(Name = "Transmisión virtual")]
        public int TransmisionVirtual { get; set; }
        [Display(Name = "Guión evento")]
        public byte[] GuionEvento { get; set; }
        [Display(Name = "Logos socios")]
        public string LogosSocios { get; set; }
        [Display(Name = "Autoridades asitirán")]
        public string PersonasAsistiran { get; set; }
        [Display(Name = "Personal WV involucrado")]
        public string PersonalWV { get; set; }
        [Display(Name = "Situaciones de interés para WV")]
        public string SituacionesInteresWV { get; set; }
        [Display(Name = "Socios a interactuar")]
        public string SociosInteractuar { get; set; }
        //public DateTime? FechaRequiereProducto { get; set; }
        //public string DescripciónProducto { get; set; }
        //public string ObjetivoProducto { get; set; }
        //public string PublicoObjetivo { get; set; }
        [Display(Name = "Mensaje clave")]
        public string MensajeClave { get; set; }
        [Display(Name = "Documento base de trabajo")]
        public byte[] DocumentoBase { get; set; }

        public int IdSolicitud { get; set; }
        public virtual SolicitudViewModel Solicitudes { get; set; }
        public ICollection<PonenteViewModel> Ponentes { get; set; }
        public ICollection<LogoSocioViewModel> LogoSocios { get; set; }
    }
}
