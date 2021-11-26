namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class DatosContactoStep : StepViewModel
    {
        public string PaisResidencia { get; set; }
        public string ProvinciaResidencia { get; set; }
        public string CiudadResidencia { get; set; }
        public string CalleResidencia { get; set; }
        public string NumCasaResidencia { get; set; }
        public string CalleSecundariaResidencia { get; set; }
        public string InfoResidencia { get; set; }
        public string SectorResidencia { get; set; }
        public string ReferenciaResidencia { get; set; }
        public string CodigoArea { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CuentaBancaria
        {
            get; set;
        }
        public DatosContactoStep()
        {
            Position = 1;
        }
    }
}

