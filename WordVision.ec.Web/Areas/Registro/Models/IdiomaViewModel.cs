using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class IdiomaViewModel
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public decimal Hablado { get; set; }
        public decimal Escrito { get; set; }
        public int IdFormulario { get; set; }
        //public Formulario Formularios
        //{
        //    get; set;
        //}
    }
}
