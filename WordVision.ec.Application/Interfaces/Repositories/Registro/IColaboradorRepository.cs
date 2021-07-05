using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IColaboradorRepository
    {
        IQueryable<Colaborador> Colaboradores { get; }

        Task<List<Colaborador>> GetListAsync();

        Task<Colaborador> GetByIdAsync(int colaboradorId);
        Task<Colaborador> GetByIdentificacionAsync(string identificacion);

        Task<int> InsertAsync(Colaborador colaborador);

        Task UpdateAsync(Colaborador colaborador);

        Task DeleteAsync(Colaborador colaborador);
    }
}
