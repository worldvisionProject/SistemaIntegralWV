using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IActividadRepository
    {
        IQueryable<Actividad> Actividades { get; }

        Task<List<Actividad>> GetListAsync();
        Task<List<Actividad>> GetListxObjetivoAsync(int idObjetivoEstrategico, int idColaborador);
        Task<Actividad> GetByIdAsync(int actividadId);
        Task<List<Actividad>> GetListByIdAsync(int idIndicador);
        Task<int> InsertAsync(Actividad actividad);

        Task UpdateAsync(Actividad actividad);

        Task DeleteAsync(Actividad actividad);
    }
}
