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
    public class EProyectoRepository : IEProyectoRepository
    {
        private readonly IRepositoryAsync<EProyecto> _repository;

        public EProyectoRepository(IRepositoryAsync<EProyecto> repository)
        {
            _repository = repository;
        }

        public IQueryable<EProyecto> EProyectos => _repository.Entities;
        public async Task<List<EProyecto>> GetListAsync(bool incluir)
        {
            if (incluir)
                return await _repository.Entities.Include(c => c.EObjetivos).ThenInclude(c => c.EIndicadores).ToListAsync();
            else
                return await _repository.Entities.ToListAsync();
        }
        public async Task<EProyecto> GetByIdAsync(int idEProyecto)
        {
            return await _repository.Entities.Where(x => x.Id == idEProyecto).Include(c => c.EObjetivos).ThenInclude(c => c.EIndicadores).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(EProyecto eProyecto)
        {
            await _repository.AddAsync(eProyecto);
            return eProyecto.Id;
        }
        public async Task UpdateAsync(EProyecto eProyecto)
        {
            await _repository.UpdateAsync(eProyecto);
        }
        public async Task DeleteAsync(EProyecto eProyecto)
        {
            await _repository.DeleteAsync(eProyecto);
        }



    }
}
