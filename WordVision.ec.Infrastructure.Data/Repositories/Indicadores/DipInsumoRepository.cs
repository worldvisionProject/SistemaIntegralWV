using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class DipInsumoRepository : IDipInsumoRepository
    {
        private readonly IRepositoryAsync<DipInsumo> _repository;
        public DipInsumoRepository(IRepositoryAsync<DipInsumo> repository)
        {
            _repository = repository;
        }

        public async Task<DipInsumo> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<DipInsumo>> GetListAsync(DipInsumo entity)
        {
            IQueryable<DipInsumo> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(p => p.EtapaModeloProyecto).Include(p => p.AccionOperativa);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(DipInsumo entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(DipInsumo entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
