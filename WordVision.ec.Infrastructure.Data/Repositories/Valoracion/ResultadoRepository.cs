using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly IRepositoryAsync<Resultado> _repository;
        private readonly IDistributedCache _distributedCache;
        public ResultadoRepository(IRepositoryAsync<Resultado> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }
        public IQueryable<Resultado> resultados => _repository.Entities;

        public async Task DeleteAsync(Resultado resultado)
        {
            await _repository.DeleteAsync(resultado);
        }

        public async Task<Resultado> GetByIdAsync(int resultadoId)
        {
            return await _repository.Entities.Where(x => x.Id == resultadoId)
               .Include(x => x.ObjetivoAnioFiscales)
               .ThenInclude(m => m.Objetivos)
               .Include(x => x.PlanificacionResultados)
               .FirstOrDefaultAsync();
        }

        public async Task<List<Resultado>> GetListAsync()
        {
            return await _repository.Entities
                .Include(x => x.ObjetivoAnioFiscales)
               .ThenInclude(m => m.Objetivos)
               .Include(x => x.PlanificacionResultados).ToListAsync();
        }

        public async Task<List<Resultado>> GetListxAnioAsync(int idObjetivoAnioFiscal, int idObjetivo)
        {
            return await _repository.Entities
                 
                 .Where(c => c.IdObjetivoAnioFiscal == idObjetivoAnioFiscal)
                 .ToListAsync();
        }
    

        public async Task<int> InsertAsync(Resultado resultado)
        {
            await _repository.AddAsync(resultado);
            return resultado.Id;
        }

        public async Task UpdateAsync(Resultado resultado)
        {
            await _repository.UpdateAsync(resultado);
        }
    }
}
