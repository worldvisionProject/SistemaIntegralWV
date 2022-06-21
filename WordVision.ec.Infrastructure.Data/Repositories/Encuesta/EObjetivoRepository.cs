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
    public class EObjetivoRepository : IEObjetivoRepository
    {
        private readonly IRepositoryAsync<EObjetivo> _repository;

        public EObjetivoRepository(IRepositoryAsync<EObjetivo> repository)
        {
            _repository = repository;
        }

        public IQueryable<EObjetivo> EObjetivos => _repository.Entities;
        public async Task<List<EObjetivo>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<EObjetivo> GetByIdAsync(string idEObjetivo)
        {
            return await _repository.Entities.Where(x => x.Id == idEObjetivo).FirstOrDefaultAsync();
        }

        public async Task<string> InsertAsync(EObjetivo eObjetivo)
        {
            await _repository.AddAsync(eObjetivo);
            return eObjetivo.Id;
        }
        public async Task UpdateAsync(EObjetivo eObjetivo)
        {
            await _repository.UpdateAsync(eObjetivo);
        }
        public async Task DeleteAsync(EObjetivo eObjetivo)
        {
            await _repository.DeleteAsync(eObjetivo);
        }



    }
}
