using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    class FormularioTerceroRepository : IFormularioTerceroRepository
    {
        private readonly IRepositoryAsync<FormularioTercero> _repository;

        //private readonly IDistributedCache _distributedCache;
        public FormularioTerceroRepository(IRepositoryAsync<FormularioTercero> repository)
        {

            _repository = repository;

        }
        public IQueryable<FormularioTercero> formularioTerceros => _repository.Entities;

        public Task DeleteAsync(FormularioTercero formularioTercero)
        {
            throw new NotImplementedException();
        }

        public Task<FormularioTercero> GetByIdAsync(int formularioTerceroId)
        {
            throw new NotImplementedException();
        }

        public Task<FormularioTercero> GetByIdFormularioAsync(int formularioId)
        {
            throw new NotImplementedException();
        }

        public Task<List<FormularioTercero>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(FormularioTercero formularioTercero)
        {
            await _repository.AddAsync(formularioTercero);
            return formularioTercero.Id;
        }

        public Task UpdateAsync(FormularioTercero formularioTercero)
        {
            throw new NotImplementedException();
        }
    }
}
