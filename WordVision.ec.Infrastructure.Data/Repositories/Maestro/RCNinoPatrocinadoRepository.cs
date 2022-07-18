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
    public class RCNinoPatrocinadoRepository: IRCNinoPatrocinadoRepository
    {
        private readonly IRepositoryAsync<RCNinoPatrocinado> _repository;
        public RCNinoPatrocinadoRepository(IRepositoryAsync<RCNinoPatrocinado> repository)
        {
            _repository = repository;
        }

        public async Task<RCNinoPatrocinado> GetByIdAsync(int id, bool include = false)
        {
            IQueryable<RCNinoPatrocinado> list = _repository.Entities.Where(p => p.Id == id);

            if (include)
            {
                list = list.Include(p => p.ProgramaArea).Include(g => g.Genero)
                .Include(e => e.GrupoEtario).Include(e => e.Estado);
            }
            return await list.FirstOrDefaultAsync();
        }

        public async Task<List<RCNinoPatrocinado>> GetListAsync(RCNinoPatrocinado rCNinoPatrocinado)
        {
            IQueryable<RCNinoPatrocinado> list = _repository.Entities;

            if (!string.IsNullOrEmpty(rCNinoPatrocinado.Codigo) && !string.IsNullOrEmpty(rCNinoPatrocinado.Cedula))
                list = list.Where(c => c.Codigo == rCNinoPatrocinado.Codigo || c.Cedula == rCNinoPatrocinado.Cedula);

            if (rCNinoPatrocinado.Include)
            {
                list = list.Include(p => p.ProgramaArea).Include(g => g.Genero)
                .Include(e => e.GrupoEtario).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        private async Task<List<RCNinoPatrocinado>> GetListAsy(RCNinoPatrocinado rCNinoPatrocinado)
        {
            IQueryable<RCNinoPatrocinado> list = _repository.Entities;

            if (!string.IsNullOrEmpty(rCNinoPatrocinado.Codigo) && !string.IsNullOrEmpty(rCNinoPatrocinado.Cedula))
                list = list.Where(c => c.Codigo == rCNinoPatrocinado.Codigo || c.Cedula == rCNinoPatrocinado.Cedula);

            if (rCNinoPatrocinado.Include)
            {
                list = list.Include(p => p.ProgramaArea).Include(g => g.Genero)
                .Include(e => e.GrupoEtario).Include(e => e.Estado);
            }

            return await list.ToListAsync();
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

        public async Task DeleteAsync(RCNinoPatrocinado rCNinoPatrocinado)
        {
            await _repository.DeleteAsync(rCNinoPatrocinado);
        }
    }
}
