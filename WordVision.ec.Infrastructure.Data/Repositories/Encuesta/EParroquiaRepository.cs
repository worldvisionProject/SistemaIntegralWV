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
    public class EParroquiaRepository : IEParroquiaRepository
    {
        private readonly IRepositoryAsync<EParroquia> _repository;

        public EParroquiaRepository(IRepositoryAsync<EParroquia> repository)
        {
            _repository = repository;
        }

        public IQueryable<EParroquia> EParroquias => _repository.Entities;
        public async Task<List<EParroquia>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<EParroquia> GetByIdAsync(string idEParroquia)
        {
            return await _repository.Entities.Where(x => x.Id == idEParroquia).Include(c => c.ECanton).FirstOrDefaultAsync();
        }

        public async Task<string> InsertAsync(EParroquia eParroquia)
        {
            await _repository.AddAsync(eParroquia);
            return eParroquia.Id;
        }
        public async Task UpdateAsync(EParroquia eParroquia)
        {
            await _repository.UpdateAsync(eParroquia);
        }
        public async Task DeleteAsync(EParroquia eParroquia)
        {
            await _repository.DeleteAsync(eParroquia);
        }




    }
}
