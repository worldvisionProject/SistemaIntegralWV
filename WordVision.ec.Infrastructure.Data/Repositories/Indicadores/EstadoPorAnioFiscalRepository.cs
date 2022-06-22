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
    public class EstadoPorAnioFiscalRepository : IEstadoPorAnioFiscalRepository
    {
        private readonly IRepositoryAsync<EstadoPorAnioFiscal> _repository;
        public EstadoPorAnioFiscalRepository(IRepositoryAsync<EstadoPorAnioFiscal> repository)
        {
            _repository = repository;
        }

        public async Task<EstadoPorAnioFiscal> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<EstadoPorAnioFiscal>> GetListAsync(EstadoPorAnioFiscal entity)
        {
            IQueryable<EstadoPorAnioFiscal> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(e => e.EstadoAnioFiscal).Include(p=> p.Proceso);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(EstadoPorAnioFiscal entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(EstadoPorAnioFiscal entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
