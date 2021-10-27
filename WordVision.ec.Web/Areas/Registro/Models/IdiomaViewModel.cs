using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class IdiomaViewModel
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar valores entre {0} y {1}")]
        public decimal Hablado { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar valores entre {0} y {1}")]
        public decimal Escrito { get; set; }
        public int IdFormulario { get; set; }
        //public Formulario Formularios
        //{
        //    get; set;
        //}
    }
}
