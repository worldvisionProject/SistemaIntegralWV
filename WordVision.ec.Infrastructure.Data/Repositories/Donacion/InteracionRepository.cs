using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Infrastructure.Data.Contexts;

namespace WordVision.ec.Infrastructure.Data.Repositories.Donacion
{
    public class InteracionRepository : IInteracionRepository
    {
        private readonly RegistroDbContext _db;
        private readonly IRepositoryAsync<Interacion> _repository;
        
      
        public InteracionRepository(RegistroDbContext db, IRepositoryAsync<Interacion> repository )
        {
            _repository = repository;
            
           
            _db = db;
        }

        public IQueryable<Interacion> interacion => _repository.Entities;

        public async Task DeleteAsync(Interacion interacion)
        {
            await _repository.DeleteAsync(interacion);
        }

        public async Task<Interacion> GetByIdAsync(int idInteracion)
        {
            return await _repository.Entities.Where(x => x.Id == idInteracion).FirstOrDefaultAsync();
        }

        public async Task<Interacion> GetInteracionAsync(int idInteracion)
        {
            return await _repository.Entities.Where(x => x.Id == idInteracion).FirstOrDefaultAsync();
        }


        public async Task<int> InsertAsync(Interacion interacion)
        {
            await _repository.AddAsync(interacion);
            return interacion.Id;
        }

        public async Task UpdateAsync(Interacion interacion)
        {
            await _repository.UpdateAsync(interacion);
        }
    }
}
