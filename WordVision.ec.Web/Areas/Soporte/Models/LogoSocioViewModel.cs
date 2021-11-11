namespace WordVision.ec.Web.Areas.Soporte.Models
{
    public class LogoSocioViewModel
    {
        public int Id { get; set; }
        public string Socio { get; set; }
        public byte[] Logo { get; set; }
        public int IdComunicacion { get; set; }
    }
}
