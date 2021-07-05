namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllPaged
{
    public class GetAllGestionesResponse
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string Identificacion { get; set; }
        public string Cargo { get; set; }

        public string Area { get; set; }

        public string LugarTrabajo { get; set; }
    }
}