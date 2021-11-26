using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class Ponente : AuditableEntity
    {
        public string NombreApellido { get; set; }
        public string Cargo { get; set; }

        public string Perfil { get; set; }
        public string Tema { get; set; }

        public int IdComunicacion { get; set; }
        public virtual Comunicacion Comunicaciones { get; set; }
    }
}
