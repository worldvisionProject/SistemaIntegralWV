namespace WordVision.ec.Application.Features.Registro.Documentos.Queries.GetAllPaged
{
    public class GetAllDocumentosResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAcepto { get; set; }
        public string Estado { get; set; }
    }
}