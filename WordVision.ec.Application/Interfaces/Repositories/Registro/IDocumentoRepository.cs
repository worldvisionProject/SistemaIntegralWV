using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IDocumentoRepository
    {
        IQueryable<Documento> Documentos { get; }

        Task<List<Documento>> GetListAsync();

        Task<Documento> GetByIdAsync(int DocumentoId);

        Task<int> InsertAsync(Documento Documento);

        Task UpdateAsync(Documento Documento);

        //Task DeleteAsync(Documento Documento);
    }
}
