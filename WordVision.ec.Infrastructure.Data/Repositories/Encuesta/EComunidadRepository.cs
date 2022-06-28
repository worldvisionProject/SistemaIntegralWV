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
    public class EComunidadRepository : IEComunidadRepository
    {
        private readonly IRepositoryAsync<EComunidad> _repository;

        public EComunidadRepository(IRepositoryAsync<EComunidad> repository)
        {
            _repository = repository;
        }

        public IQueryable<EComunidad> EComunidades => _repository.Entities;
        public async Task<List<EComunidad>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<EComunidad> GetByIdAsync(string idEComunidad)
        {
            return await _repository.Entities.Where(x => x.Id == idEComunidad).FirstOrDefaultAsync();
        }

        public async Task<string> InsertAsync(EComunidad eComunidad)
        {
            await _repository.AddAsync(eComunidad);
            return eComunidad.Id;
        }
        public async Task UpdateAsync(EComunidad eComunidad)
        {
            await _repository.UpdateAsync(eComunidad);
        }
        public async Task DeleteAsync(EComunidad eComunidad)
        {
            await _repository.DeleteAsync(eComunidad);
        }


    }
}
