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
    public class ECantonRepository : IECantonRepository
    {
        private readonly IRepositoryAsync<ECanton> _repository;

        public ECantonRepository(IRepositoryAsync<ECanton> repository)
        {
            _repository = repository;
        }

        public IQueryable<ECanton> ECantones => _repository.Entities;
        public async Task<List<ECanton>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<ECanton> GetByIdAsync(string idECanton)
        {
            return await _repository.Entities.Where(x => x.Id == idECanton).Include(c => c.EProvincia).FirstOrDefaultAsync();
        }

        public async Task<string> InsertAsync(ECanton eCanton)
        {
            await _repository.AddAsync(eCanton);
            return eCanton.Id;
        }
        public async Task UpdateAsync(ECanton eCanton)
        {
            await _repository.UpdateAsync(eCanton);
        }
        public async Task DeleteAsync(ECanton eCanton)
        {
            await _repository.DeleteAsync(eCanton);
        }


    }
}
