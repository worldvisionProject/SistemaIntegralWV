using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface IDonanteRepository
    {
        IQueryable<Donante> donantes { get; }
        Task<List<Donante>> GetListAsync();

        Task<int> InsertAsync(Donante donante);

        Task UpdateAsync(Donante donante);
        Task DeleteAsync(Donante donante);
        Task<Donante> GetDonantesAsync(int idDonante);
       
    }
}
