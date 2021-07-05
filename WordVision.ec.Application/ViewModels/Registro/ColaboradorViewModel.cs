using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.ViewModels.Registro
{
    public class ColaboradorViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Apellidos obligatorio")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Primer Nombre obligatorio")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        [Required(ErrorMessage = "Segundo Nombre obligatorio")]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "Identificacion obligatorio")]
        [Display(Name = "Identificacion")]
        public string Identificacion { get; set; }


    }
}
