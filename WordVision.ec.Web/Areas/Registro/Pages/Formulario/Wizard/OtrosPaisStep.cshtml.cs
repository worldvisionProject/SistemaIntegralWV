using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class OtrosPaisStep : StepViewModel
    {
        public string CedulaExtranjero { get; set; }
        public string CiudadaniaExtranjero { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? VigenciaDesde { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? VigenciaHasta { get; set; }

        public string DobleCiudadaniaSN { get; set; }
        public string PaisCiudadania { get; set; }


        public OtrosPaisStep()
        {
            Position = 2;
        }
    }
}
