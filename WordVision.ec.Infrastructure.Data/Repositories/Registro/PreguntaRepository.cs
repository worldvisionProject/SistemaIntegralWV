using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    class PreguntaRepository : IPreguntaRepository
    {
        private readonly IRepositoryAsync<Pregunta> _repository;
        private readonly IDistributedCache _distributedCache;
        public PreguntaRepository(IDistributedCache distributedCache, IRepositoryAsync<Pregunta> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Pregunta> Preguntas => _repository.Entities;

        public async Task<Pregunta> GetByIdAsync(int PreguntaId)
        {
            return await _repository.Entities.Where(p => p.Id == PreguntaId).FirstOrDefaultAsync();
        }

        public async Task<List<Pregunta>> GetByIdDocumentoAsync(int documentoId)
        {
            return await _repository.Entities.Where(p => p.IdDocumento == documentoId).ToListAsync();
        }

        public async Task<List<Pregunta>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public Task<int> InsertAsync(Pregunta pregunta)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Pregunta pregunta)
        {
            throw new NotImplementedException();
        }
    }
}
