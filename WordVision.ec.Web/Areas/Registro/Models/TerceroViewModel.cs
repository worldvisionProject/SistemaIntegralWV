using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class TerceroViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Identificacion { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime? FecNacimiento { get; set; }
        public string? Genero { get; set; }
        public DateTime? VigDesde { get; set; }
        public DateTime? VigHasta { get; set; }

        public string CodigoArea { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public int idFormulario { get; set; }
        public int IdColaborador { get; set; }
        public string TipoGrupo { get; set; }
        //public List<FormularioTerceroViewModel> FormularioTerceros { get; set; }
    }
}
