using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetAllCached
{
    public class GetAllEstructurasCachedResponse
    {
        public int Id { get; set; }
        public string Designacion { get; set; }
        public int ReportaID { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}