using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Registro.TechoPresupuestarios.Queries.GetAllCached
{
    public class GetAllTechoPresupuestariosResponse
    {
        public int Id { get; set; }
        public string CodigoCC { get; set; }
        public string DescripcionCC { get; set; }
        public decimal? Techo { get; set; }
    }
}