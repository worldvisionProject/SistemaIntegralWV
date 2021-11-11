using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;


namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface IPonenteRepository
    {
        IQueryable<Ponente> Ponentes { get; }
        Task<List<Ponente>> GetListAsync(int IdComunicacion);

        Task<int> InsertAsync(Ponente ponente);

        Task UpdateAsync(Ponente ponente);
        Task DeleteAsync(Ponente ponente);
        Task<Ponente> GetByIdAsync(int idPonente);
      
    }
}
