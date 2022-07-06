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
    public class EProvinciaRepository : IEProvinciaRepository
    {
        private readonly IRepositoryAsync<EProvincia> _repository;

        public EProvinciaRepository(IRepositoryAsync<EProvincia> repository)
        {
            _repository = repository;
        }

        public IQueryable<EProvincia> EProvincias => _repository.Entities;
        public async Task<List<EProvincia>> GetListAsync(bool incluir)
        {
            if (incluir)
                return await _repository.Entities.Include(c => c.ECantones).Include(c => c.eRegion).ToListAsync();
            else
                return await _repository.Entities.ToListAsync();
        }
        public async Task<List<EProvincia>> GetListAsync(bool incluir, int padre)
        {
            if (incluir)
                return await _repository.Entities.Where(x => x.eRegion.Id == padre).Include(c => c.ECantones).Include(c => c.eRegion).ToListAsync();
            else
                return await _repository.Entities.Where(x => x.eRegion.Id == padre).ToListAsync();
        }
        public async Task<EProvincia> GetByIdAsync(string idEProvincia)
        {
            return await _repository.Entities.Where(x => x.Id == idEProvincia).Include(c => c.eRegion).Include(c => c.ECantones).FirstOrDefaultAsync();
        }

        public async Task<string> InsertAsync(EProvincia eProvincia)
        {
            await _repository.AddAsync(eProvincia);
            return eProvincia.Id;
        }
        public async Task UpdateAsync(EProvincia eProvincia)
        {
            await _repository.UpdateAsync(eProvincia);
        }
        public async Task DeleteAsync(EProvincia eProvincia)
        {
            await _repository.DeleteAsync(eProvincia);
        }


    }
}
