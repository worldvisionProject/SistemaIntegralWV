using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Soporte
{
    public class Personal : AuditableEntity
    {
        public int IdPersonal { get; set; }
        public int IdArea { get; set; }
        public int IdPersona { get; set; }


    }
}
