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
    public class EIndicadorUsuarioRepository : IEIndicadorUsuarioRepository
    {

        private readonly IRepositoryAsync<EIndicadorUsuario> _repository;

        public EIndicadorUsuarioRepository(IRepositoryAsync<EIndicadorUsuario> repository)
        {
            _repository = repository;
        }

        public IQueryable<EIndicadorUsuario> EIndicadorUsuarios => _repository.Entities;
        public async Task<List<EIndicadorUsuario>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<EIndicadorUsuario> GetByIdAsync(int idEIndicadorUsuario)
        {
            return await _repository.Entities.Where(x => x.Id == idEIndicadorUsuario).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(EIndicadorUsuario eIndicadorUsuario)
        {
            await _repository.AddAsync(eIndicadorUsuario);
            return eIndicadorUsuario.Id;
        }
        public async Task UpdateAsync(EIndicadorUsuario eIndicadorUsuario)
        {
            await _repository.UpdateAsync(eIndicadorUsuario);
        }
        public async Task DeleteAsync(EIndicadorUsuario eIndicadorUsuario)
        {
            await _repository.DeleteAsync(eIndicadorUsuario);
        }






    }
}
