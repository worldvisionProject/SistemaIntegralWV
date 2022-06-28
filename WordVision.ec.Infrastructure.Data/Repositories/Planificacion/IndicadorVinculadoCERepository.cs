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
    public class IndicadorVinculadoCERepository : IIndicadorVinculadoCERepository
    {
        private readonly IRepositoryAsync<IndicadorVinculadoCE> _repository;
      
        public IndicadorVinculadoCERepository(IRepositoryAsync<IndicadorVinculadoCE> repository)
        {
            _repository = repository;
        }
        public IQueryable<IndicadorVinculadoCE> IndicadorVinculadoCEs => _repository.Entities;

        public async Task DeleteAsync(IndicadorVinculadoCE indicadorVinculadoCE)
        {
            await _repository.DeleteAsync(indicadorVinculadoCE);
        }

        public async Task<IndicadorVinculadoCE> GetByIdAsync(int indicadorVinculadoCEId)
        {
            return await _repository.Entities.Where(p => p.Id == indicadorVinculadoCEId).FirstOrDefaultAsync();
        }
    }
}
