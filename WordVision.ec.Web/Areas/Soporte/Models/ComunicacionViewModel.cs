using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class ComunicacionViewModel
    {
        public int Id { get; set; }
        public int TipoSolicitud { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public decimal Presupuesto { get; set; }
        public byte[] DisponibilidadPresupuestaria { get; set; }
        public byte[] AutorizaciondelLider { get; set; }
        //public string Informativo { get; set; }

        //public int Responsable { get; set; }

        //public int NumdeTicketTI { get; set; }

        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public DateTime? HoraEvento { get; set; }

        public string LugarEvento { get; set; }
        public string ObjetivoEvento { get; set; }
        public string PublicoObjetivo { get; set; }
        public int NumeroParticipantes { get; set; }
        public bool TransmisionVirtual { get; set; }
        public string GuionEvento { get; set; }
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
        public virtual SolicitudViewModel Solicitudes { get; set; }
    }
}
