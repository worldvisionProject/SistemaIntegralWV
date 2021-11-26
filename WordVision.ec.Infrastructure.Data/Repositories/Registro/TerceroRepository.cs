using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    class TerceroRepository : ITerceroRepository
    {
        private readonly IRepositoryAsync<Tercero> _repository;
        private readonly IRepositoryAsync<FormularioTercero> _repFormulario;

        //private readonly IDistributedCache _distributedCache;
        public TerceroRepository(IRepositoryAsync<Tercero> repository, IRepositoryAsync<FormularioTercero> repFormulario)
        {

            _repository = repository;
            _repFormulario = repFormulario;


        }
        public IQueryable<Tercero> Terceros => _repository.Entities;

        public async Task DeleteAsync(Tercero tercero)
        {
            await _repository.DeleteAsync(tercero);
        }

        public async Task<Tercero> GetByIdAsync(int terceroId)
        {
            return await _repository.Entities.Where(p => p.Id == terceroId).Include(x => x.FormularioTerceros).FirstOrDefaultAsync();
        }

        public async Task<List<FormularioTercero>> GetByIdFormularioAsync(int formularioId, string tipo)
        {
            return await _repFormulario.Entities.Where(p => p.Formularios.Id == formularioId && p.Tipo == tipo).Include(x => x.Terceros).ToListAsync();

        }

        public async Task<List<Tercero>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }


        public async Task<int> InsertAsync(Tercero tercero)
        {
            await _repository.AddAsync(tercero);
            return tercero.Id;
        }

        public async Task UpdateAsync(Tercero tercero)
        {
            await _repository.UpdateAsync(tercero);
        }
    }
}
