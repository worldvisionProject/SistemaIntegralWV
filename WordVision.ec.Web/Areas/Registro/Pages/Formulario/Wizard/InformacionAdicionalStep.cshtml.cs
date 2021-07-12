using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class InformacionAdicionalStep : StepViewModel
    {
        public int Id { get; set; }
        public string Idioma { get; set; }
        public int PorcentajeHablado { get; set; }
        public int PorcentajeEscrito { get; set; }
        public string CreenciaReligiosa { get; set; }
        public string Iglesia { get; set; }
        public string Etnia { get; set; }
        public string DiscapacidadSN { get; set; }
        public string TipoDiscapacidad { get; set; }
        public int? PorcentajeDiscapacidad { get; set; }
        public string FamiliaDiscapacidadSN { get; set; }
        public string FamiliaTipoDiscapacidad { get; set; }
        public int? FamiliaPorcentajeDiscapacidad { get; set; }
        public string FamiliaDiscapacidad { get; set; }
        public string FamiliaDiscapacidadRelacion { get; set; }
        public string Colaborador { get; set; }
        public string Identificacion { get; set; }
        public byte[] Image { get; set; }
        public ICollection<IdiomaViewModel> Idiomas { get; set; }
        public InformacionAdicionalStep()
        {
            Position = 6;
        }
    }
}
