using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Firma.Queries.GetById
{
    public class GetFirmaByIdResponse
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public Colaborador Colaboradores { get; set; }

        public int IdDocumento { get; set; }

        public byte[] Image { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
