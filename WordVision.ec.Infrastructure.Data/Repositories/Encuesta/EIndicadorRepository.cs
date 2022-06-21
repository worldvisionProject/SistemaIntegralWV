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
    public class EIndicadorRepository : IEIndicadorRepository
    {
        private readonly IRepositoryAsync<EIndicador> _repository;

        public EIndicadorRepository(IRepositoryAsync<EIndicador> repository)
        {
            _repository = repository;
        }

        public IQueryable<EIndicador> EIndicadores => _repository.Entities;
        public async Task<List<EIndicador>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<EIndicador> GetByIdAsync(string idEIndicador)
        {
            return await _repository.Entities.Where(x => x.Id == idEIndicador).FirstOrDefaultAsync();
        }

        public async Task<string> InsertAsync(EIndicador eIndicador)
        {
            await _repository.AddAsync(eIndicador);
            return eIndicador.Id;
        }
        public async Task UpdateAsync(EIndicador eIndicador)
        {
            await _repository.UpdateAsync(eIndicador);
        }
        public async Task DeleteAsync(EIndicador eIndicador)
        {
            await _repository.DeleteAsync(eIndicador);
        }


    }
}
