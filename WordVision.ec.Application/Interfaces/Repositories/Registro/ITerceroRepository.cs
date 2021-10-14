using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface ITerceroRepository
    {
        IQueryable<Tercero> Terceros { get; }

        Task<List<Tercero>> GetListAsync();

        Task<Tercero> GetByIdAsync(int terceroId);

        Task<List<FormularioTercero>> GetByIdFormularioAsync(int formularioId, string tipo);
      
        Task<int> InsertAsync(Tercero tercero);

        Task UpdateAsync(Tercero tercero);

        Task DeleteAsync(Tercero tercero);
    }
}
