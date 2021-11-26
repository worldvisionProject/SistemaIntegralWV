using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Ponentes.Queries.GetAll
{
    public class GetAllPonentesResponse
    {
        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public string Cargo { get; set; }

        public string Perfil { get; set; }
        public string Tema { get; set; }

        public int IdComunicacion { get; set; }
        public virtual Comunicacion Comunicaciones { get; set; }
    }
}
