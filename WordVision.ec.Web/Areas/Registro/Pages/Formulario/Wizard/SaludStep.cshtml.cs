namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class SaludStep : StepViewModel
    {
        public string TipoSangre { get; set; }
        public string Preexistencia { get; set; }
        public string Alergias { get; set; }

        public SaludStep()
        {
            Position = 4;
        }
    }
}
