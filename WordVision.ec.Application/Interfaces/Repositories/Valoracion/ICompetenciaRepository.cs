using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface ICompetenciaRepository
    {
        IQueryable<Competencia> Competencias { get; }

        Task<List<Competencia>> GetListAsync();
        Task<Competencia> GetByIdAsync(int competenciaId);
        Task<List<CompetenciaResponse>> GetListPadreAsync(int idNivel);
        Task<List<Competencia>> GetListxPadreAsync(int idPadre);
        Task<int> InsertAsync(Competencia competencia);

        Task UpdateAsync(Competencia competencia);

        Task DeleteAsync(Competencia competencia);
    }
}
