using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IRepositoryAsync<Producto> _repository;
        private readonly IDistributedCache _distributedCache;

        public ProductoRepository(IDistributedCache distributedCache, IRepositoryAsync<Producto> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Producto> Productos => _repository.Entities;

        public async Task DeleteAsync(Producto producto)
        {
            await _repository.DeleteAsync(producto);
        }

        public async Task<Producto> GetByIdAsync(int productoId, int idColaborador, string idCreadoPor)
        {
            return await _repository.Entities.Where(p => p.Id == productoId).Include(x => x.IndicadorEstrategicos).ThenInclude(e => e.IndicadorAFs)
                .Include(x => x.IndicadorPOAs.Where(i => i.Responsable == idColaborador || (idColaborador == 0) || (i.CreatedBy == idCreadoPor || idCreadoPor == ""))).ThenInclude(m => m.MetaTacticas).FirstOrDefaultAsync();
        }

        public async Task<List<Producto>> GetListAsync()
        {
            return await _repository.Entities
                .Include(i => i.IndicadorEstrategicos)
                .ThenInclude(h => h.IndicadorAFs)
                .Include(f => f.IndicadorEstrategicos)
                .ThenInclude(h => h.FactorCriticoExitos)
                .ToListAsync();
        }

        //public async Task<List<Producto>> GetListByIdAsync(int idIndicador, int idColaborador)
        //{
        //    return await _repository.Entities.Where(p => p.IdIndicadorEstrategico == idIndicador && p.IdCargoResponsable==idColaborador)
        //        .Include(i=>i.IndicadorPOAs.Where(x=>x.Responsable == idColaborador))
        //        .ThenInclude(m=>m.Actividades.Where(x => x.IdCargoResponsable == idColaborador))
        //        .ToListAsync();
        //}
        public async Task<List<Producto>> GetListByIdAsync(int idIndicador)
        {
            return await _repository.Entities.Where(p => p.IdIndicadorEstrategico == idIndicador)
                .Include(i => i.IndicadorPOAs)
                .ThenInclude(m => m.Actividades)
                .ToListAsync();
        }
        public async Task<List<Producto>> GetListByIdObjetivoAsync(int idObjetivoEstrategico, int idColaborador)
        {
            return await _repository.Entities
                .Include(i => i.IndicadorPOAs.Where(x => x.Responsable == idColaborador))
                .ThenInclude(m => m.Actividades.Where(x1 => x1.IdCargoResponsable == idColaborador))
                .Include(u => u.IndicadorEstrategicos)
                .ThenInclude(g => g.IndicadorAFs)
                .Include(u => u.IndicadorEstrategicos)
                .ThenInclude(f => f.FactorCriticoExitos)
                .Where(p => p.IndicadorEstrategicos.FactorCriticoExitos.IdObjetivoEstra == idObjetivoEstrategico && p.IdCargoResponsable == idColaborador)
                .ToListAsync();
        }

        public async Task<int> InsertAsync(Producto producto)
        {
            await _repository.AddAsync(producto);
            return producto.Id;
        }

        public async Task UpdateAsync(Producto producto)
        {
            await _repository.UpdateAsync(producto);
        }
    }
}
