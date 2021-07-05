using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class DatosPersonalesStep : StepViewModel
    {
        public ColaboradorViewModel Colaboradores { get; set; }
        public string Identificacion { get; set; }
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

