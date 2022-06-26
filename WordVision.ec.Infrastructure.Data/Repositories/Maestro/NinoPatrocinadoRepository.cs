using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class NinoPatrocinadoRepository : INinoPatrocinadoRepository
    {
        private readonly IRepositoryAsync<RCNinoPatrocinado> _repository;
        public NinoPatrocinadoRepository(IRepositoryAsync<RCNinoPatrocinado> repository)
        {
            _repository = repository;
        }

        public async Task<RCNinoPatrocinado> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<RCNinoPatrocinado>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(RCNinoPatrocinado rCNinoPatrocinado)
        {
            await _repository.AddAsync(rCNinoPatrocinado);
            return rCNinoPatrocinado.Id;
        }

        public async Task UpdateAsync(RCNinoPatrocinado rCNinoPatrocinado)
        {
            await _repository.UpdateAsync(rCNinoPatrocinado);
        }
    }
}
