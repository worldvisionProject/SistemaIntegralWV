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
    public class EProgramaRepository : IEProgramaRepository
    {
        private readonly IRepositoryAsync<EPrograma> _repository;

        public EProgramaRepository(IRepositoryAsync<EPrograma> repository)
        {
            _repository = repository;
        }

        public IQueryable<EPrograma> EProgramas => _repository.Entities;
        public async Task<List<EPrograma>> GetListAsync(bool incluir)
        {
            if (incluir)
                return await _repository.Entities.Include(c => c.EParroquias).Include(c => c.EProgramaIndicadores).ToListAsync();
            else
                return await _repository.Entities.ToListAsync();
        }
        public async Task<EPrograma> GetByIdAsync(string idEPrograma)
        {
            return await _repository.Entities.Where(x => x.Id == idEPrograma).Include(c => c.EParroquias).FirstOrDefaultAsync();
        }

        public async Task<string> InsertAsync(EPrograma ePrograma)
        {
            await _repository.AddAsync(ePrograma);
            return ePrograma.Id;
        }
        public async Task UpdateAsync(EPrograma ePrograma)
        {
            await _repository.UpdateAsync(ePrograma);
        }
        public async Task DeleteAsync(EPrograma ePrograma)
        {
            await _repository.DeleteAsync(ePrograma);
        }




    }
}
