using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IFormularioTerceroRepository
    {
        IQueryable<FormularioTercero> formularioTerceros { get; }

        Task<List<FormularioTercero>> GetListAsync();

        Task<FormularioTercero> GetByIdAsync(int formularioTerceroId);

        Task<FormularioTercero> GetByIdFormularioAsync(int formularioId);

        Task<int> InsertAsync(FormularioTercero formularioTercero);

        Task UpdateAsync(FormularioTercero formularioTercero);

        Task DeleteAsync(FormularioTercero formularioTercero);
    }
}
