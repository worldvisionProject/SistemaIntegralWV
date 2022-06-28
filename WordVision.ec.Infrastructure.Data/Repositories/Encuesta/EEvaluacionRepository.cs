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
    public class EEvaluacionRepository : IEEvaluacionRepository
    {
        private readonly IRepositoryAsync<EEvaluacion> _repository;

        public EEvaluacionRepository(IRepositoryAsync<EEvaluacion> repository)
        {
            _repository = repository;
        }

        public IQueryable<EEvaluacion> EEvaluaciones => _repository.Entities;
        public async Task<List<EEvaluacion>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<EEvaluacion> GetByIdAsync(int idEEvaluacion)
        {
            return await _repository.Entities.Where(x => x.Id == idEEvaluacion).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(EEvaluacion eEvaluacion)
        {
            await _repository.AddAsync(eEvaluacion);
            return eEvaluacion.Id;
        }
        public async Task UpdateAsync(EEvaluacion eEvaluacion)
        {
            await _repository.UpdateAsync(eEvaluacion);
        }
        public async Task DeleteAsync(EEvaluacion eEvaluacion)
        {
            await _repository.DeleteAsync(eEvaluacion);
        }

    }
}
