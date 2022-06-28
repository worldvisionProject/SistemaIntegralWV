using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IEscalaRepository
    {
        IQueryable<Escala> Escalas { get; }

        Task<List<Escala>> GetListAsync();
        Task<Escala> GetByIdAsync(int escalaId);

        Task<Escala> GetByValorEscalaAsync(decimal valorEscala);

        Task<int> InsertAsync(Escala escala);

        Task UpdateAsync(Escala escala);

        Task DeleteAsync(Escala escala);
    }
}
