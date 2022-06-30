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
    public class PaisRepository : IPaisRepository
    {
        private readonly IRepositoryAsync<Pais> _repository;
        private readonly IRepositoryAsync<Provincia> _repositoryProvincia;
        private readonly IRepositoryAsync<Ciudad> _repositoryCiudad;
        private readonly IDistributedCache _distributedCache;

        public PaisRepository(IRepositoryAsync<Ciudad> repositoryCiudad,IDistributedCache distributedCache, IRepositoryAsync<Provincia> repositoryProvincia, IRepositoryAsync<Pais> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
            _repositoryProvincia = repositoryProvincia;
            _repositoryCiudad = repositoryCiudad;
        }
        public IQueryable<Pais> paises =>_repository.Entities;

        public async Task<Pais> GetByIdAsync(int idPais)
        {
            return await _repository.Entities.Where(pais => pais.Id == idPais)
                .Include(p=>p.Provincias)
                .ThenInclude(c =>c.Ciudades)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Ciudad>> GetByIdProvinciaAsync(int idProvincia)
        {
            return await _repositoryCiudad.Entities.Where(pais => pais.IdProvincia == idProvincia)
                .Include(c => c.Provincias)
                .ThenInclude(p => p.Paises)
                .ToListAsync();
        }

        public async Task<List<Provincia>> GetByIdRegionAsync(int idRegion)
        {
            return await _repositoryProvincia.Entities.Where(pais => pais.Region == idRegion)
               .Include(c => c.Ciudades)
               .Include(p=>p.Paises)
               .ToListAsync();
        }

        public async Task<List<Pais>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
    }
}
