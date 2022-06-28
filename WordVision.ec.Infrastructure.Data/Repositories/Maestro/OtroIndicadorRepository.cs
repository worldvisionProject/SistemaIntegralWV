using Microsoft.EntityFrameworkCore;
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
    public class OtroIndicadorRepository : IOtroIndicadorRepository
    {
        private readonly IRepositoryAsync<OtroIndicador> _repository;
        public OtroIndicadorRepository(IRepositoryAsync<OtroIndicador> repository)
        {
            _repository = repository;
        }

        public async Task<OtroIndicador> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<OtroIndicador>> GetListAsync(OtroIndicador OtroIndicador)
        {
            IQueryable<OtroIndicador> list = _repository.Entities;

            if (!string.IsNullOrEmpty(OtroIndicador.Codigo))
                list = list.Where(c => c.Codigo == OtroIndicador.Codigo);

            if (OtroIndicador.Include)
            {
                list = list.Include(p => p.Frecuencia).Include(t=> t.TipoIndicador)
                    .Include(p=> p.ActorParticipante).Include(p=> p.Area)
                    .Include(p=> p.TipoMedida).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(OtroIndicador OtroIndicador)
        {
            await _repository.AddAsync(OtroIndicador);
            return OtroIndicador.Id;
        }

        public async Task UpdateAsync(OtroIndicador OtroIndicador)
        {
            await _repository.UpdateAsync(OtroIndicador);
        }
    }
}
