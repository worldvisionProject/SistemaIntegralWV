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
    public class Solicitud : AuditableEntity
    {


        public string TipoSistema { get; set; }

        //Estructura de Mensajeria

        [Required]
        public int Solicitante { get; set; }

        [StringLength(15)]
        public string PersonaaContactar { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }
        [StringLength(10)]
        public string Celular { get; set; }

        public DateTime FechaRequerida { get; set; }

        //public string Ruta { get; set; }
        //public string NombreArchivo { get; set; }
        public byte[] Archivo { get; set; }

        public int TiposTramites { get; set; }

        [StringLength(500)]
        public string DescripcionTramite { get; set; }

        [StringLength(500)]
        public string Direccion { get; set; }

        [StringLength(500)]
        public string InformacionAdicional { get; set; }


        public int AsignadoA { get; set; }


        public int Estado { get; set; }


       
        public string DescripcionSolucion { get; set; }

       
        public string ObservacionesSolucion { get; set; }

        public int EstadoSatisfaccion { get; set; }

       

    [ForeignKey("IdSolicitud")]

        //Tabla PAdre
        public ICollection<EstadosSolicitud> EstadosSolicitudes { get; set; }

        //Estructura de Comunicaciones

        public int NumSolicitud { get; set; }

        public int TipoSolicitud { get; set; }

        public int AreaSolicitante { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public decimal Presupuesto { get; set; }
        public string DisponibilidadPresupuestaria { get; set; }
        public string AutorizacióndelLíderInmediato { get; set; }
        public string Informativo { get; set; }

        public int Responsable { get; set; }

        public  int NumdeTicketTI { get; set; }

        public string NombredelEvento { get; set; }
        public DateTime FechadelEvento { get; set; }
        public DateTime HoradelEvento { get; set; }

        public string LugarEvento { get; set; }
        public string ObjetivodelEvento { get; set; }
        public string PúblicoObjetivo { get; set; }
        public int NúmerodeParticipantesEstimado { get; set; }
        public bool TransmisiónVirtual { get; set; }
        public string GuionMinuto_a_MinutoEvento { get; set; }
        public string LogosSociosInvolucrados { get; set; }
        public string PersonasAutoridadesAsistirán { get; set; }
        public string PersonalWVInvolucrado { get; set; }
        public string SituacionesInteresParaWorldVision { get; set; }

        public string SociosQuienesInteractuar { get; set; }
        public DateTime FechaRequiereProducto { get; set; }
        public string DescripciónProducto { get; set; }
        public string ObjetivoProducto { get; set; }
        public string PublicoObjetivo { get; set; }
        public string MensajeClave { get; set; }
        public string DocumentoBasedeTrabajo { get; set; }




    }
}
