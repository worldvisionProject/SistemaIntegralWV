using System.Collections.Generic;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class ContactosStep : StepViewModel
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }

        public int NumContacto { get; set; }
        public List<FormularioTerceroViewModel> FormularioTerceros { get; set; }
        public ContactosStep()
        {
            Position = 5;
        }
    }
}
