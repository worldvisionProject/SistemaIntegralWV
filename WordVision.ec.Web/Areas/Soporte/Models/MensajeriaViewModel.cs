using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class MensajeriaViewModel
    {
        public int Id { get; set; }
        public string PersonaaContactar { get; set; }

        public string Telefono { get; set; }
        public string Celular { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaRequerida { get; set; }
        public byte[] Archivo { get; set; }
        public int TiposTramites { get; set; }
        public string DescripcionTramite { get; set; }
        public string Direccion { get; set; }
        public string InformacionAdicional { get; set; }

        public int IdSolicitud { get; set; }
        public virtual SolicitudViewModel Solicitudes { get; set; }
    }
}
