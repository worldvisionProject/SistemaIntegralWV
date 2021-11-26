namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class FormularioTerceroViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual TerceroViewModel Terceros { get; set; }
    }
}
