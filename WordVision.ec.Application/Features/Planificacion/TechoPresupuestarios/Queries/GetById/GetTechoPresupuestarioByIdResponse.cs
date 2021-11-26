namespace WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Queries.GetById
{
    public class GetTechoPresupuestarioByIdResponse
    {
        public int Id { get; set; }
        public string CodigoCC { get; set; }
        public string DescripcionCC { get; set; }
        public decimal? Techo { get; set; }
    }
}
