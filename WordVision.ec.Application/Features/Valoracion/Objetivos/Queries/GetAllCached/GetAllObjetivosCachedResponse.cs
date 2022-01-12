using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetAllCached
{
   public class GetAllObjetivosCachedResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Estado { get; set; }
    }
}
