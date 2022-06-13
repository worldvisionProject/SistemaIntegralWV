using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Features.Maestro.Catalogos;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;

namespace WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado
{
    public class RCNinoPatrocinadoResponse : GenericResponse
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Comunidad { get; set; }

        public int Edad { get; set; }

        public bool Patrocinado { get; set; }

        public int IdGrupoEtario { get; set; }
        public DetalleCatalogoResponse GrupoEtario { get; set; }

        public int IdGenero { get; set; }
        public DetalleCatalogoResponse Genero { get; set; }

        public int IdEstado { get; set; }

        public DetalleCatalogoResponse Estado { get; set; }

        public int IdProgramaArea { get; set; }

        public ProgramaAreaResponse ProgramaArea { get; set; }
    }
}
