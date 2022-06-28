using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class IndicadorVinculadoERepository : IIndicadorVinculadoERepository
    {
        private readonly IRepositoryAsync<IndicadorVinculadoE> _repository;
      
        public IndicadorVinculadoERepository(IRepositoryAsync<IndicadorVinculadoE> repository)
        {
            _repository = repository;
        }
        public IQueryable<IndicadorVinculadoE> IndicadorVinculadoEs => _repository.Entities;

        public async Task DeleteAsync(IndicadorVinculadoE indicadorVinculadoE)
        {
            await _repository.DeleteAsync(indicadorVinculadoE);
        }

        public async Task<IndicadorVinculadoE> GetByIdAsync(int indicadorVinculadoEId)
        {
            return await _repository.Entities.Where(p => p.Id == indicadorVinculadoEId).FirstOrDefaultAsync();
        }
    }
}
