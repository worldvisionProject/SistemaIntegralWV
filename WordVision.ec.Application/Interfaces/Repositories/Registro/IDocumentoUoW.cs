using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
   public  interface IDocumentoUoW : IUnitOfWork<RegistroDbContext>, IDocumentoRepository
    {
    }
}
