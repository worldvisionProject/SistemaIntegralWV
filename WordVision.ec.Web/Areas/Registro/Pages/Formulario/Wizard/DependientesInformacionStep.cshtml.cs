using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class DependientesInformacionStep : StepViewModel
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public List<FormularioTerceroViewModel> FormularioTerceros { get; set; }
        public DependientesInformacionStep()
        {
            Position = 3;
        }
    }
}
