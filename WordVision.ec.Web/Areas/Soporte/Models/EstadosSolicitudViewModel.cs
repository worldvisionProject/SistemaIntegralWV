namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class EstadosSolicitudViewModel
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public int IdSolicitud { get; set; }
        //Tabla Padre
        public SolicitudViewModel Solicitudes { get; set; }
    }
}
