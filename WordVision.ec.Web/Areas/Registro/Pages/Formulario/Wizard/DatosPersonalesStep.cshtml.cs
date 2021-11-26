using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class DatosPersonalesStep : StepViewModel
    {
        public ColaboradorViewModel Colaboradores { get; set; }
        public string Identificacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public string FormacionAcademica { get; set; }


        public DatosPersonalesStep()
        {
            Position = 0;
        }
    }
}

