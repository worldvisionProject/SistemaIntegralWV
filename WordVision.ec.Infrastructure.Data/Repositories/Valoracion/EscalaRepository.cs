using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class EscalaRepository : IEscalaRepository
    {
        private readonly IRepositoryAsync<Escala> _repository;
         public EscalaRepository(IRepositoryAsync<Escala> repository)
        {
            _repository = repository;
           
        }
        public IQueryable<Escala> Escalas => _repository.Entities;

        public async Task DeleteAsync(Escala escala)
        {
            await _repository.DeleteAsync(escala);
        }

        public async Task<Escala> GetByIdAsync(int escalaId)
        {
            return await _repository.Entities.Where(x => x.Id == escalaId)
               .FirstOrDefaultAsync();
        }

        public async Task<Escala> GetByValorEscalaAsync(decimal valorEscala)
        {
            return await _repository.Entities.Where(x => x.EscalaInicio >= valorEscala && x.EscalaInicio <= valorEscala)
               .FirstOrDefaultAsync();
        }

        public async Task<List<Escala>> GetListAsync()
        {
            return await _repository.Entities
                .ToListAsync();
        }

        public async Task<int> InsertAsync(Escala escala)
        {
            await _repository.AddAsync(escala);
            return escala.Id;
        }

        public async Task UpdateAsync(Escala escala)
        {
            await _repository.UpdateAsync(escala);
        }
    }
}
