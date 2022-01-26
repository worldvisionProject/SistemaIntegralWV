namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class ResponsabilidadViewModel
    {
        public int Id { get; set; }
        public int IdEstructura { get; set; }
        public string Nombre { get; set; }
        public string Indicador { get; set; }
        public int Tipo { get; set; }
        public int IdResponsabilidad { get; set; }
        public int Padre { get; set; }
    }
}
