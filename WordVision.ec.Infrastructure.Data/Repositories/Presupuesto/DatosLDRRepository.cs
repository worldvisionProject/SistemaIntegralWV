using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Presupuesto;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Presupuesto
{
    public class DatosLDRRepository : IDatosLDRRepository
    {
        private readonly IRepositoryAsync<DatosLDR> _repository;
        private readonly IRepositoryAsync<Colaborador> _colaboradorRepository;
        private readonly IDistributedCache _distributedCache;

        public DatosLDRRepository(IRepositoryAsync<Colaborador> colaboradorRepository, IDistributedCache distributedCache, IRepositoryAsync<DatosLDR> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
            _colaboradorRepository = colaboradorRepository;
        }
        public IQueryable<DatosLDR> DatosLDRs => _repository.Entities;

        public async Task DeleteAsync(DatosLDR datosLdr)
        {
            await _repository.DeleteAsync(datosLdr);

        }

        public async Task<DatosLDR> GetByIdAsync(int datosLdrId)
        {

            return await _repository.Entities.Where(p => p.Id == datosLdrId).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAreaAsync(int area)
        {

            int contar = _colaboradorRepository.Entities.Count(x => x.Area == area);
            return contar;
        }

        public async Task<int> GetCountNacionalAsync()
        {
            int contar = _colaboradorRepository.Entities.Count();
            return contar;
        }

        public async Task<List<DatosLDR>> GetListAsync()
        {

            return await _repository.Entities.ToListAsync();

        }

        public async Task<int> InsertAsync(DatosLDR datosLdr)
        {
            await _repository.AddAsync(datosLdr);

            return datosLdr.Id;
        }

        public async Task UpdateAsync(DatosLDR datosLdr)
        {
            await _repository.UpdateAsync(datosLdr);

        }
    }
}
