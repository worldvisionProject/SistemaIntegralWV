using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Identity;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Identity
{
    public interface IIdentityCacheRepository
    {
        Task<List<UsuariosActiveDirectory>> GetCachedListAsync();

        Task<UsuariosActiveDirectory> GetByIdAsync(string usuarioId);
    }
}
