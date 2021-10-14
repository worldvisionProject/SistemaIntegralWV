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
    class FormularioRepository : IFormularioRepository
    {
        private readonly IRepositoryAsync<Formulario> _repository;
    
        private readonly IDistributedCache _distributedCache;
        public FormularioRepository(IDistributedCache distributedCache, IRepositoryAsync<Formulario> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
       
        }
        public IQueryable<Formulario> Formularios => _repository.Entities;

        public async Task<Formulario> GetByIdAsync(int FormularioId)
        {

            return await _repository.Entities.Where(p => p.IdColaborador == FormularioId).Include(x => x.Colaboradores)
                .Include(z=>z.FormularioTerceros)
                .ThenInclude(c=>c.Terceros)
                .Include(v=>v.Idiomas)
                .FirstOrDefaultAsync();

           // return await _repository.Entities.Where(p => p.Colaboradores.Id == FormularioId).FirstOrDefaultAsync();
        }

       
        public async Task<Formulario> GetByIdFormularioAsync(int DocumentoId)
        {
            return await _repository.Entities.Where(p => p.Id == DocumentoId).FirstOrDefaultAsync();
        }

        public async Task<List<Formulario>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Formulario formulario)
        {
            await _repository.AddAsync(formulario);
            // await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            return formulario.Id;
        }

        public async Task UpdateAsync(Formulario formulario)
        {
            await _repository.UpdateAsync(formulario);
            //await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            //await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.GetKey(formulario.Id));
        }
    }
}
