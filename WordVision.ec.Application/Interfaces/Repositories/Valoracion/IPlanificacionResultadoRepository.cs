using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IPlanificacionResultadoRepository
    {
        IQueryable<PlanificacionResultado> planificacionResultados { get; }

        Task<List<PlanificacionResultado>> GetListAsync();
        Task<List<PlanificacionResultado>> GetListxObjetivoAsync(int idObjetivo);
        Task<List<ObjetivoResponse>> GetListxObjetivoxColaboradorAsync(int idAnioFiscal, int idColaborador);

        Task<List<PlanificacionResultadoResponse>> GetListxColaboradorAsync(int idObjetivoAnioFiscal, int idColaborador);
        Task<PlanificacionResultado> GetByIdAsync(int planificacionResultadoId);
        Task<int> InsertAsync(PlanificacionResultado planificacionResultado);

        Task UpdateAsync(PlanificacionResultado planificacionResultado);

        Task DeleteAsync(PlanificacionResultado planificacionResultado);
    }
}
