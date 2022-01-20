using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IObjetivoRepository
    {
        IQueryable<Objetivo> Objetivos { get; }

        Task<List<Objetivo>> GetListAsync();
        Task<Objetivo> GetByIdAsync(int objetivoId);
        Task<ObjetivoAnioFiscal> GetPonderacionByIdAsync(int objetivoId);
        Task<List<Objetivo>> GetListxAnioFiscalAsync(int idAnioFiscal);
        Task<int> InsertAsync(Objetivo objetivo);

        Task UpdateAsync(Objetivo objetivo);

        Task DeleteAsync(Objetivo objetivo);  
    }
}
