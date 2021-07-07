namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById
{
    public class GetGestionByIdResponse
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Anio { get; set; }

        public string Estado { get; set; }
        public int IdEstrategia { get; set; }
    }
}