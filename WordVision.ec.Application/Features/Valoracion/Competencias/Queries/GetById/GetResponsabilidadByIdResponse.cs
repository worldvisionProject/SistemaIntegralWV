using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Valoracion.Competencias.Queries.GetById
{
    public class GetCompetenciaByIdResponse
    {
        public int Id { get; set; }
        public int IdNivel { get; set; }
       
        public string NombreCompetencia { get; set; }
        public string Descripcion { get; set; }
        public int EsObligatorio { get; set; }
        public string Comportamiento { get; set; }
       
        public int IdCompetencia { get; set; }
       
        public int Padre { get; set; }
    }
}
