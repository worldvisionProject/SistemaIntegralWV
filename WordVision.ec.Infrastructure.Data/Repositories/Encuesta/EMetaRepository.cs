using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Encuesta;
using WordVision.ec.Application.DTOs.Encuesta;
using System;
using Newtonsoft.Json.Linq;

namespace WordVision.ec.Infrastructure.Data.Repositories.Encuesta
{
    public class EMetaRepository : IEMetaRepository
    {
        private readonly IRepositoryAsync<EMeta> _repository;

        public EMetaRepository(IRepositoryAsync<EMeta> repository)
        {
            _repository = repository;
        }

        public IQueryable<EMeta> EMetas => _repository.Entities;
        public async Task<List<EMeta>> GetListAsync(bool incluir)
        {
            if (incluir)
                return await _repository.Entities.Include(c => c.EIndicador).Include(c => c.EPrograma).Include(c => c.EEvaluacion).ToListAsync();
            else
                return await _repository.Entities.ToListAsync();
        }
        public async Task<EMeta> GetByIdAsync(int idEMeta)
        {
            return await _repository.Entities.Where(x => x.Id == idEMeta).Include(c => c.EIndicador).Include(c => c.EPrograma).Include(c => c.EEvaluacion).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(EMeta eMeta)
        {
            await _repository.AddAsync(eMeta);
            return eMeta.Id;
        }
        public async Task UpdateAsync(EMeta eMeta)
        {
            await _repository.UpdateAsync(eMeta);
        }
        public async Task DeleteAsync(EMeta eMeta)
        {
            await _repository.DeleteAsync(eMeta);
        }






    }
}
