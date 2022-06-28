using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IResultadoRepository
    {
        IQueryable<Resultado> resultados { get; }

        Task<List<Resultado>> GetListAsync();

        Task<List<ResultadoResponse>> GetListxAnioAsync(int idObjetivoAnioFiscal, int idObjetivo);
        Task<Resultado> GetByIdAsync(int resultadoId);
        Task<int> InsertAsync(Resultado resultado);

        Task UpdateAsync(Resultado resultado);

        Task DeleteAsync(Resultado resultado);
    }
}
