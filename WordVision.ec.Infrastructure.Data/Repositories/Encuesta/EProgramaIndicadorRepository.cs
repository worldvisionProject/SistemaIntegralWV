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
    public class EProgramaIndicadorRepository : IEProgramaIndicadorRepository
    {
        private readonly IRepositoryAsync<EProgramaIndicador> _repository;

        public EProgramaIndicadorRepository(IRepositoryAsync<EProgramaIndicador> repository)
        {
            _repository = repository;
        }

        public IQueryable<EProgramaIndicador> EProgramaIndicadores => _repository.Entities;
        public async Task<List<EProgramaIndicador>> GetListAsync(bool incluir)
        {
            if (incluir)
                return await _repository.Entities.Include(c => c.EIndicador).Include(c => c.EPrograma).ToListAsync();
            else
                return await _repository.Entities.ToListAsync();
        }
        public async Task<EProgramaIndicador> GetByIdAsync(int idEProgramaIndicador)
        {
            return await _repository.Entities.Where(x => x.Id == idEProgramaIndicador).Include(c => c.EIndicador).Include(c => c.EPrograma).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(EProgramaIndicador eProgramaIndicador)
        {
            await _repository.AddAsync(eProgramaIndicador);
            return eProgramaIndicador.Id;
        }
        public async Task UpdateAsync(EProgramaIndicador eProgramaIndicador)
        {
            await _repository.UpdateAsync(eProgramaIndicador);
        }
        public async Task DeleteAsync(EProgramaIndicador eProgramaIndicador)
        {
            await _repository.DeleteAsync(eProgramaIndicador);
        }






    }
}
