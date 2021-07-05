namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllPaged
{
    public class GetAllEstrategiaNacionalesResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Causa { get; set; }
        public string MetaRegional { get; set; }
        public string MetaNacional { get; set; }
        public int IdEmpresa { get; set; }
        public string Estado { get; set; }
    }
}