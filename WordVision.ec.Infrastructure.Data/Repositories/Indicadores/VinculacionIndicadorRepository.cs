using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class VinculacionIndicadorRepository : IVinculacionIndicadorRepository
    {
        private readonly IRepositoryAsync<VinculacionIndicador> _repository;
        public VinculacionIndicadorRepository(IRepositoryAsync<VinculacionIndicador> repository)
        {
            _repository = repository;
        }

        public async Task<VinculacionIndicador> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<VinculacionIndicador>> GetListAsync(VinculacionIndicador entity)
        {
            IQueryable<VinculacionIndicador> list = _repository.Entities;

            //if (!string.IsNullOrEmpty(VinculacionIndicador.Codigo))
            //    list = list.Where(c => c.Codigo == VinculacionIndicador.Codigo);

            if (entity.Include)
            {
                list = list.Include(p => p.IndicadorPR).Include(p => p.OtroIndicador)
                       .Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(VinculacionIndicador entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(VinculacionIndicador entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
