using System.Collections.Generic;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetById
{
    public class GetEstructuraByIdResponse
    {
        public int Id { get; set; }
        public string Designacion { get; set; }
        public int ReportaID { get; set; }
        public int Estado { get; set; }
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}