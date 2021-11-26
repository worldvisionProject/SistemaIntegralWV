using System.Collections.Generic;
using System.Linq;
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
        Task<Colaborador> GetByUserNameAsync(string username);
        Task<List<Colaborador>> GetByNivelAsync(int nivel1, int nivel2);
        Task<List<Colaborador>> GetByIdAreaAsync(int idArea);
        Task<Colaborador> GetByEstructuraAsync(int idEstructura);
        Task<int> InsertAsync(Colaborador colaborador);

        Task UpdateAsync(Colaborador colaborador);

        Task DeleteAsync(Colaborador colaborador);
    }
}
