using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class ResponsabilidadRepository : IResponsabilidadRepository
    {
        private readonly IRepositoryAsync<Responsabilidad> _repository;
        private readonly IDistributedCache _distributedCache;
        public ResponsabilidadRepository(IRepositoryAsync<Responsabilidad> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }
        public IQueryable<Responsabilidad> responsabilidades => _repository.Entities;

        public async Task DeleteAsync(Responsabilidad responsabilidad)
        {
            await _repository.DeleteAsync(responsabilidad);
        }

        public async Task<Responsabilidad> GetByIdAsync(int responsabilidadId)
        {
            return await _repository.Entities.Where(x => x.Id == responsabilidadId)
               .FirstOrDefaultAsync();
        }

        public async Task<List<Responsabilidad>> GetListAsync()
        {
            return await _repository.Entities
               .ToListAsync();
        }

        public async Task<List<ResponsabilidadResponse>> GetListPadreAsync(int idEstructura,int idObjetivoAnioFiscal)
        {
            return await _repository.Entities.Where(g => g.IdEstructura== idEstructura && g.IdObjetivoAnioFiscal== idObjetivoAnioFiscal)
                .Select(x => new ResponsabilidadResponse
                {   /*Id=x.Id,*/
                    IdResponsabilidad = x.IdResponsabilidad,
                    NombreResponsabilidad = x.Nombre,
                    Descripcion = x.Descripcion,
                    EsObligatorio = x.EsObligatorio
                }).Distinct().ToListAsync();
        }

        public async Task<List<Responsabilidad>> GetListxPadreAsync(int idPadre)
        {
            return await _repository.Entities.Where(x => x.Padre == idPadre).ToListAsync();
        }

        public async Task<int> InsertAsync(Responsabilidad responsabilidad)
        {
            await _repository.AddAsync(responsabilidad);
            return responsabilidad.Id;
        }

        public async Task UpdateAsync(Responsabilidad responsabilidad)
        {
            await _repository.UpdateAsync(responsabilidad);
        }
    }
}
