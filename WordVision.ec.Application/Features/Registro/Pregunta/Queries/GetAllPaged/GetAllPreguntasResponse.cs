namespace WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllPaged
{
    public class GetAllPreguntasResponse
    {
        public int Id { get; set; }
        public int NumPregunta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAcepto { get; set; }
        public string DescripcionUrl1 { get; set; }
        public string Url1 { get; set; }
        public string DescripcionUrl2 { get; set; }
        public string Url2 { get; set; }

        public string Estado { get; set; }

        public int IdDocumento { get; set; }
    }
}