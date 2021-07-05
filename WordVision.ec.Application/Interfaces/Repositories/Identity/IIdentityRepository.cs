using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Identity;

namespace WordVision.ec.Application.Interfaces.Repositories.Identity
{
    public interface IIdentityRepository
    {
        IQueryable<UsuariosActiveDirectory> UsuariosActiveDirectory { get; }

        Task<List<UsuariosActiveDirectory>> GetListAsync();

        Task<UsuariosActiveDirectory> GetByIdAsync(string usuarioId);
        Task UpdateAsync(UsuariosActiveDirectory usuario);
    }
}
