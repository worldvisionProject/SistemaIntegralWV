using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class SolicitudViewModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }

        [Display(Name = "Fecha de Solicitud")]
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int TipoSistema { get; set; }
        public int IdAsignadoA { get; set; }
        public string AsignadoA { get; set; }
        public SelectList AsignadoAList { get; set; }
        public int Estado { get; set; }
        public SelectList EstadoList { get; set; }
        public SelectList TiposTramitesList { get; set; }
        public string DescripcionSolucion { get; set; }
        public string ObservacionesSolucion { get; set; }
        public string ComentarioSatisfaccion { get; set; }
        public int EstadoSatisfaccion { get; set; }
        public ICollection<EstadosSolicitudViewModel> EstadosSolicitudes { get; set; }

        public MensajeriaViewModel Mensajerias { get; set; }

        public ComunicacionViewModel Comunicaciones { get; set; }

        public int IdColaborador { get; set; }
        public virtual ColaboradorViewModel Colaboradores { get; set; }
        public int Op { get; set; }
        public int Fin { get; set; }
    }
}
