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
    public class ERegionRepository : IERegionRepository
    {
        private readonly IRepositoryAsync<ERegion> _repository;

        public ERegionRepository(IRepositoryAsync<ERegion> repository)
        {
            _repository = repository;
        }

        public IQueryable<ERegion> ERegiones => _repository.Entities;
        public async Task<List<ERegion>> GetListAsync()
        {
            return await _repository.Entities.Include(c => c.EProvincias).ToListAsync();
        }
        public async Task<ERegion> GetByIdAsync(int idERegion)
        {
            return await _repository.Entities.Where(x => x.Id == idERegion).Include(c => c.EProvincias).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(ERegion eRegion)
        {
            await _repository.AddAsync(eRegion);
            return eRegion.Id;
        }
        public async Task UpdateAsync(ERegion eRegion)
        {
            await _repository.UpdateAsync(eRegion);
        }
        public async Task DeleteAsync(ERegion eRegion)
        {
            await _repository.DeleteAsync(eRegion);
        }



    }
}
