using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Web.Areas.Registro.Models
{
    public class FirmaViewModel
    {
        public int IdColaborador { get; set; }
        public Colaborador Colaboradores { get; set; }
        public int IdDocumento { get; set; }

        public byte[] Image { get; set; }
    }
}
