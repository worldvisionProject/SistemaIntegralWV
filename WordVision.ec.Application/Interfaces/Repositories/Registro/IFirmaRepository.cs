using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IFirmaRepository
    {
        IQueryable<Firma> Firmas { get; }

        Task<List<Firma>> GetListAsync();

        Task<Firma> GetByIdAsync(int firmaId);
        Task<Firma> GetByIdColaboradorAsync(int colaboradorId, int documentoId);

        Task<int> InsertAsync(Firma firma);

        Task UpdateAsync(Firma firma);
    }
}