using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface IPersonalRepository
    {
        Task<List<Personal>> GetListAsync();

        Task<int> InsertAsync(Personal personal);

        Task UpdateAsync(Personal personal);
        Task DeleteAsync(Personal personal);
        Task<Personal> GetPonenteAsync(int idPersonal);
    }
}
