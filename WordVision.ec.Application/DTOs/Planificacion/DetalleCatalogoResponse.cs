namespace WordVision.ec.Application.DTOs.Planificacion
{
    public class DetalleCatalogoResponse
    {
        public int Id { get; set; }
        public int IdCatalogo { get; set; }
        public string Secuencia { get; set; }
        public string Nombre { get; set; }

        public int Estado { get; set; }
    }
}
